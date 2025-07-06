using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive
{
	internal class CMath
	{
		static private double CalculateRegression(List<double> _axis_Y)
		{
			int n = _axis_Y.Count;

			List<double> _axis_X = new List<double>();
			for(int i = 0; i< n; i++)
			{
				_axis_X.Add(i);
			}

			double sumX = 0;
			double sumY = 0;
			double sumXY = 0;
			double sumXX = 0;

			for (int i = 0; i < n; i++)
			{
				sumX += _axis_X[i];
				sumY += _axis_Y[i];
				sumXY += _axis_X[i] * _axis_Y[i];
				sumXX += _axis_X[i] * _axis_X[i];
			}

			double slope=  (n * sumXY - sumX * sumY) / (n * sumXX - sumX * sumX);
			double angleInRadians = Math.Atan(slope);
			return angleInRadians * (180 / Math.PI);
		}

		//计算主力净额斜率
		static public List<double> CalculateMarketValue(List<double> _axis_Y)
		{
			List<double> slopes = new List<double>();

			//上升区时必须是主力加仓, 数据如果小于0表示是减仓, 直接退出
			if (_axis_Y.Last() <= 0.0) return slopes;

			//下降区
			for (int i = 0; i < (_axis_Y.Count - 1); i++)
			{
				//下降区主力是减仓的, 如果大于0表示是加仓, 不符合条件, 直接退出
				if (_axis_Y.ElementAt(i) > 0.0) return slopes;

				//加速减仓给了很好的反馈
				//if (i > 0)
				//{
				//	if (_axis_Y.ElementAt(i) < _axis_Y.ElementAt(i + 1)) return slopes;
				//}
			}

			//将数据拆分为下降区和上升区
			//下降区
			List<double> decrease_area = new List<double>();
			List<double> decrease_area_temp = new List<double>();
			foreach (double x in _axis_Y) 
			{
				decrease_area.Add(x);
				decrease_area_temp.Add(0.0);
			}
			decrease_area.RemoveAt(decrease_area.Count - 1);

			for (int i = 0; i < decrease_area.Count; i++)
			{
				for (int j = i + 1; j < decrease_area.Count; j++)
				{
					decrease_area_temp[j] += decrease_area[i];
				}
			}

			for (int i = 0; i < decrease_area.Count; i++)
			{
				decrease_area[i] += decrease_area_temp[i];
			}

			//上升区
			List<double> increase_area = new List<double>();
			increase_area.Add(0.0);
			increase_area.Add(_axis_Y.Last());

			//计算斜率
			slopes.Add(CalculateRegression(decrease_area));
			slopes.Add(CalculateRegression(increase_area));

			return slopes;
		}

		//计算股价斜率
		static public List<double> CalculateTicketValue(List<double> _axis_Y)
		{
			List<double> slopes = new List<double>();

			//上升区时股价肯定是要涨的, 如果是下降, 则退出
			if (_axis_Y.ElementAt(_axis_Y.Count - 1) <= _axis_Y.ElementAt(_axis_Y.Count - 2))
			{
				return slopes;
			}

			//将数据拆分为下降区和上升区
			//下降区
			List<double> decrease_area = _axis_Y;
			decrease_area.RemoveAt(decrease_area.Count - 1);

			//上升区
			List<double> increase_area = new List<double>();
			increase_area.Add(_axis_Y.ElementAt(_axis_Y.Count - 2));
			increase_area.Add(_axis_Y.ElementAt(_axis_Y.Count - 1));

			//计算斜率
			slopes.Add(CalculateRegression(decrease_area));
			slopes.Add(CalculateRegression(increase_area));

			return slopes;
		}
	}
}
