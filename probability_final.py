# -*- encoding: euc-kr-*-
import xgboost as xgb
import pymysql
import pandas as pd
from datetime import datetime, timezone, timedelta

conn = pymysql.connect(host='127.0.0.1', user='pbl_guest',passwd='ghkdlxld1042~!' , db='pbl4', charset='utf8')
cur = conn.cursor()

query = f"SELECT * FROM count_people ORDER BY _id DESC LIMIT 1"


xg_filename ="C:/Users/ryeon/Downloads/pbl_xg_model_1128"
check_file = []


def forecasting_people(month, dayofweek, day, hour, min):
    
    forecast_data = pd.DataFrame({
        'month':[month],
        'dayorweek':[dayofweek],
        'day':[day],
        'hour': [hour],
        'min':[min]
        })
    
    model = xgb.Booster(model_file=xg_filename)
    result = model.predict(xgb.DMatrix(forecast_data))
    
    return result

def probability(h, f, c):
    
    nume = (h/f) * 100 #��� Ȯ���� �˰� ���� ������ ��� ���� ������ �ִ� ���� �ο� ���� ���� �� 100�� ���� 
    deno = ((c*400)/f) * 100 # ������ ���� ��� ���� �ʵ��� ������ ������ �� �ִ� �ο��� 400�� ���� ��, ������ �ִ� �ο����� ���� 
    
    return (nume / deno) * 100


# t: ��� Ȯ���� �˰� ���� ����
# flag: ����ö ������ ���� 
def predicting(t, flag): 
    i = 0
    people = 0 
    korea_timezone = timezone(timedelta(hours=9))
    now_time = datetime.now(korea_timezone).strftime("%Y/%m/%d %H:%M") #���� �ð��� YYYY-MM-DD HH:MM �������� ������
    now_time_dt = pd.to_datetime(now_time) #datetime �������� ���� 
    hour = (now_time_dt.hour)

    while i < t: #��� Ȯ���� �˰� ���� �������� �ݺ�
        
        if i == 0: 
            cur.execute(query)
            people += cur.fetchone()[2] # ������ ���̽��� ����� ���� ��� ���� h������ ���� 
            i+=1
            
        else:
        
            month = (now_time_dt.month)
            dayofweek = (now_time_dt.dayofweek) 
            day = (now_time_dt.day) 
            hour = (now_time_dt.hour) + i
            mini = (now_time_dt.minute) 
  
            #hour+i �ð��� ��� ���� ���� - ���� �����ϴµ� �ʿ��� ������ �Ű������� ���� 
            #forecasting_people �Լ��� ��ȯ ���� flag�� ���� ���� people�� ���� 
            people += (forecasting_people(month, dayofweek, day, hour, mini) * flag)
            
            prob = probability(people, 960, 10)
            
            print('time:',hour, 'people:', people, 'prob:', prob)
            
            i+=1 #���� ������ ��� ���� �����ϱ� ���� i�� 1�� ���� 
                  
    

def main():
    """Main function."""
    
    predicting(6, 1)
 
    
    
if __name__ == '__main__':
    
    #opt = parse_opt()
    main()
    cur.close()


