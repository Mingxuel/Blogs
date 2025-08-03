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

def UPDATE_TRADING_DATES():
    print(f"# UPDATE_TRADING_DATES START #######")
    count = common.UPDATE_TRADING_DATES()
    print(f"[UPDATE_TRADING_DATES] TRADING DATES COUNT: {count}")
    print(f"# UPDATE_TRADING_DATES END #######")
    print("")
    return count

def UPDATE_TRADING_TIMES_1M():
    print(f"# UPDATE_TRADING_TIMES_1M START #######")
    count = common.UPDATE_TRADING_TIMES_1M()
    print(f"[UPDATE_TRADING_TIMES_1M] TRADING TIMES FOR 1M COUNT: {count}")
    print(f"# UPDATE_TRADING_TIMES_1M END #######")
    print("")

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="一个带参数的示例程序")
    parser.add_argument("-utd", "--update_trading_dates", action="store_true", help="")
    parser.add_argument("-utt1m", "--update_trading_times_1m", action="store_true", help="")
    args = parser.parse_args()

    if args.update_trading_dates:
        UPDATE_TRADING_DATES()