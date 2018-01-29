using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode128
{
    public class claBarcode
    {
		public string strBarcode(string strSData)
		{
			return strBarcode(strSData, 0);
		}
        
		public string strBarcode(string strSData, int intType)
		{			
			claCodeData insCodedata = new claCodeData();
			
			string strData = "";	
            
			switch (intType)
			{
				case 1:	//B타입
					strData = "211214";
					break;
				case 2:	//C타입
					strData = "211232";
					break;
				default: //A타입
					strData = "211412";
					break;
			}
            
			int intChar = 0;	//체크캐릭터를 구하기위한 변수

			intChar = 103;		//스타트의 가중치는 1이기때문에 103만 제공한다.


			for (int i = 1; i <= strSData.Length; i++)
			{
				//받아온 데이터의 차수를 구하고
				int intTemp = insCodedata.intReTurnN(strSData.Substring(i - 1, 1), intType);
				//데이터를 기호코드로 변환하여 바코드 데이터로 입력한다.
				strData += insCodedata.intChar[intTemp, 1];
				//체크캐릭터 계산용 데이터에 수치에 가중치를 곱한 값을 더한다.
				intChar += intTemp * i;
			}

			//체크캐릭터의 값을 103으로 나눈 나머지를 구한다.
			intChar %= 103;
			//체크캐릭터에 해당하는 수치를 찾아 바코드를 반환한다.
			strData += insCodedata.intChar[intChar, 1];
			//스톱은 2331112가 고정이다.
			strData += "2331112";

		
			return strData;	
		
		}
		
		public string strBarcodeToBar(string strData)
		{
			try
			{
				//바코드의 색을 표시하기위한 변수			
				bool booBlackAndWhite = true;

                string strTempBar = "";

				for (int i = 0; i < strData.Length; i++)
				{
					int intTemp = Convert.ToInt32(strData.Substring(i, 1));

					for (int j = 1; j <= intTemp; j++)
					{
						if (booBlackAndWhite == true)
						{
							//검정색 그리기 위하여 출력함. 
							strTempBar += "1";
						}
						else
						{
							//하얀색 그리기 위하여 출력함.
							strTempBar += "0";
						}
					}
                    // 번갈아서 출력되게... 할껀데 되려나 ㅇ알ㅇㄹ 모르겠습니다.				
					booBlackAndWhite = !booBlackAndWhite;

				}

				return strTempBar;
			}
			catch (Exception)
			{
                MessageBox.Show("오류발생");
                return "0";
			}

		}
    }
}
