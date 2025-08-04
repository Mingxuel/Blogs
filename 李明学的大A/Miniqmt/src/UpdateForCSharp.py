from decimal import ROUND_HALF_UP, Decimal
from xtquant import xtdata
import datetime
from Common import Common, DataType, MAType
import sys
from RunTime import RunTime
from Sectors import Sectors
import time
import argparse
import os, sys
import ast

HISTORY_1D_COUNT = -1

def UPDATE_TRADING_DATES():
    start_date = "20240601"
    end_date = datetime.datetime.now().strftime("%Y%m%d")
    trading_dates = xtdata.get_trading_dates('SH', start_date, end_date)
    config_file = "../../../../../Miniqmt/src/Config/交易日"
    with open(config_file, 'w') as file:
        for date in trading_dates:
            date = datetime.datetime.fromtimestamp(date/1000).strftime("%Y%m%d")
            file.write(f"{date}\n")
        return True
    return False

def UPDATE_MAIN_STOCK_LIST():
    config_file_quit = "../../../../../Miniqmt/src/Config/退市代码"
    stock_codes = []
    with open(config_file_quit, 'r') as file:
        for line in file:
            stock_codes.append(line.strip())

    config_file_main = "../../../../../Miniqmt/src/Config/主板代码"
    with open(config_file_main, 'w') as file:
        stocks = xtdata.get_stock_list_in_sector('沪深A股')
        stock_codes += stocks
        stock_codes.append('000001.SH')  # 添加上证指数
        stock_codes = sorted(stock_codes, reverse=True)
        for stock_code in stock_codes:
            if stock_code.startswith('688') or stock_code.startswith('30'): #科创/创业板
                continue
            if stock_code.startswith('90') or stock_code.startswith('20'): #B板
                continue
            elif stock_code.startswith('8'): #北交所
                continue
            else: #主板(也包含st)
                file.write(f"{stock_code}\n")
        return True
    return False

def DOWNLOAD_HISTORY_1D():
    stock_codes = STOCK_CODES()
    trading_dates = TRADING_DATES()

    pre_count = 0
    while True:
        if HISTORY_1D_COUNT == -1:
            xtdata.download_history_data2(stock_codes, "1d", trading_dates[0], trading_dates[-1])
        else:
            xtdata.download_history_data2(stock_codes, "1d", trading_dates[-HISTORY_1D_COUNT], trading_dates[-1])

        xtdata.subscribe_whole_quote(stock_codes)
        data_1d = xtdata.get_market_data_ex([], stock_codes, "1d", trading_dates[-1], trading_dates[-1], 1, fill_data=False)
        count = 0

        for stock_code in stock_codes:
            if data_1d[stock_code].size != 0 and data_1d[stock_code].index[-1] == trading_dates[-1]:
                count = count + 1
        if count < 3000 or count != pre_count:
            pre_count = count
        else:
            time.sleep(10)
            return True

def UPDATE_HISTORY_1D():
    stock_codes = STOCK_CODES()
    trading_dates = TRADING_DATES()

    xtdata.subscribe_whole_quote(stock_codes)
    data_1d = xtdata.get_market_data_ex([], stock_codes, "1d", trading_dates[0], trading_dates[-1], -1, fill_data=False)

    if len(data_1d) == 0:
        return False
    for stock_code in stock_codes:
        if stock_code not in data_1d.keys():
            continue
        config_file = f"../../../../../Miniqmt/src/Config/Data/1D/{stock_code}"
        #config_file = f"Config/Data/1D/{stock_code}"
        if os.path.exists(config_file):
            #获取最后一次更新的日期
            last_date = ""
            with open(config_file, 'r') as file:
                last_date = file.readlines()[-1].strip().split(" ")[0]
            data = data_1d[stock_code]
            #写入新数据
            with open(config_file, 'a') as file:
                for date, row in data.iterrows():
                    #判断是否有最新数据
                    if date <= last_date:
                        continue
                    #到这里了就说明有新数据
                    file.write(f"{date} ")
                    for index in data.columns[1:-1]:
                        file.write(str(ROUNDOFF(row[index])))
                        file.write(" ")
                    file.write("\n")
        else: #文件不存在，写入所有数据
            data = data_1d[stock_code]
            with open(config_file, 'a') as file:
                for index in data.columns:
                    file.write(index + " ")
                file.write("\n")
                for date, row in data.iterrows():
                    file.write(date)
                    file.write(" ")
                    for index in data.columns[1:-1]:
                        file.write(str(ROUNDOFF(row[index])))
                        file.write(" ")
                    file.write("\n")
    return True

# PRIVATE ################################################################################################
def STOCK_CODES():
    stock_codes = []
    config_file_main = "../../../../../Miniqmt/src/Config/主板代码"
    #config_file_main = "Config/主板代码"
    with open(config_file_main, 'r') as file:
        for line in file:
            stock_codes.append(line.strip())
    return stock_codes

def TRADING_DATES():
    trading_dates = []
    config_file_trading_dates = "../../../../../Miniqmt/src/Config/交易日"
    #config_file_trading_dates = "Config/交易日"
    with open(config_file_trading_dates, 'r') as file:
        for line in file:
            trading_dates.append(line.strip())
    return trading_dates

def ROUNDOFF(data):
    price = Decimal(str(data))
    price = price.quantize(Decimal('0.001'), rounding=ROUND_HALF_UP)
    return float(price.quantize(Decimal('0.01'), rounding=ROUND_HALF_UP))

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="一个带参数的示例程序")
    parser.add_argument("-utd", "--update_trading_dates", action="store_true", help="")
    parser.add_argument("-umsl", "--update_main_stock_list", action="store_true", help="")
    parser.add_argument("-dh1d", "--download_history_1d", action="store_true", help="")
    parser.add_argument("-uh1d", "--update_history_1d", action="store_true", help="")
    args = parser.parse_args()

    xtdata.enable_hello = False

    if args.update_trading_dates:
       if UPDATE_TRADING_DATES():
            print("交易日更新成功")

    if args.update_main_stock_list:
        if UPDATE_MAIN_STOCK_LIST():
            print("主板代码更新成功")

    if args.download_history_1d:
        if DOWNLOAD_HISTORY_1D():
            print("1D数据下载成功")

    if args.update_history_1d:
        if UPDATE_HISTORY_1D():
            print("1D数据更新成功")
