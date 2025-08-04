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

HISTORY_1D_COUNT = 5
HISTORY_1M_COUNT = 5
STOP_COUNT = 22

common = Common()
sectors = Sectors()

def DOWNLOAD_HISTORY_1D():
    print(f"# DOWNLOAD_HISTORY_1D START #######")
    status = True
    all_count = len(common.MAIN_STOCKS)
    while status:
        if HISTORY_1D_COUNT == -1:
            xtdata.download_history_data2(common.MAIN_STOCKS, "1d", common.TRADING_DATES[0], common.TRADING_DATES[-1])
        else:
            xtdata.download_history_data2(common.MAIN_STOCKS, "1d", common.TRADING_DATES[-HISTORY_1D_COUNT], common.TRADING_DATES[-1])
        common.RESET_MARKET_DATAS_FOR_1D()
        whole_data = common.GET_MARKET_DATAS_FOR_1D(HISTORY_1D_COUNT)
        count = 0
        for stock_code in common.MAIN_STOCKS:
            if len(whole_data[stock_code].index) == 0:
                continue
            if HISTORY_1D_COUNT == -1:
                first_date = whole_data[stock_code].index[0]
                last_date = whole_data[stock_code].index[-1]
                if first_date == common.TRADING_DATES[0] and last_date == common.TRADING_DATES[-1]:
                    count += 1
            else:
                last_date = whole_data[stock_code].index[-1]
                if last_date == common.TRADING_DATES[-1]:
                    count += 1
        if HISTORY_1D_COUNT == -1:
            count += 29
        if (count  + STOP_COUNT) >= len(common.MAIN_STOCKS):
            time.sleep(30)
            status = False
            print(f"[DOWNLOAD_HISTORY_1D] PROCESS: [{all_count}-{count}]")
            continue
        print(f"[DOWNLOAD_HISTORY_1D] PROCESS: [{all_count}-{count}]")
        time.sleep(10)
    print(f"# DOWNLOAD_HISTORY_1D END #######")
    print("")

def UPDATE_MAIN_STOCK_LIST():
    #config_file_main = "../../../../../Miniqmt/src/Config/主板代码"
    #config_file_quit = "../../../../../Miniqmt/src/Config/退市代码"
    config_file_main = "Config/主板代码"
    config_file_quit = "Config/退市代码"
    stock_codes = []
    with open(config_file_quit, 'r') as file:
        for line in file:
            stock_codes.append(line.strip())

    with open(config_file_main, 'w') as file:
        stocks = xtdata.get_stock_list_in_sector('沪深A股')
        stock_codes.append(stocks)
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

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="一个带参数的示例程序")
    parser.add_argument("-utd", "--update_trading_dates", action="store_true", help="")
    parser.add_argument("-umsl", "--update_main_stock_list", action="store_true", help="")
    parser.add_argument("-utt1m", "--update_trading_times_1m", action="store_true", help="")
    args = parser.parse_args()

    xtdata.enable_hello = False

    UPDATE_MAIN_STOCK_LIST()

    whole_stock_list = xtdata.get_stock_list_in_sector('沪深A股')

    stock_list = ["600837.SH"]
    xtdata.download_history_data2(stock_list, "1d", common.TRADING_DATES[0], common.TRADING_DATES[-1])
    xtdata.subscribe_whole_quote(stock_list)
    __market_datas_for_1d = xtdata.get_market_data_ex([], stock_list, "1d", common.TRADING_DATES[0], common.TRADING_DATES[-1], -1, fill_data=False)
    ss = xtdata.get_market_data([], stock_list, "1d", common.TRADING_DATES[0], common.TRADING_DATES[-1], -1, fill_data=False)

    if args.update_trading_dates:
        if UPDATE_TRADING_DATES():
            print("交易日更新成功")
    if args.update_main_stock_list:
        if UPDATE_MAIN_STOCK_LIST():
            print("主板代码更新成功")
