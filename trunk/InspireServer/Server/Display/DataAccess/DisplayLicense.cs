using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Inspire.Server.Display.DataAccess
{
    public class DisplayLicense
    {
        static public int GetLicense()
        {
            try
            {
                string displaysLic = ConfigurationManager.AppSettings["DisplayLicense"];
                int numOfDisplays;

                switch (displaysLic)
                {
                    case "14C71A16-96FD-4A58-80DE-A3F5ECF4E0C0": numOfDisplays = 2; break;
                    case "A25082E8-722A-43C7-B510-DA4FF9CD80A3": numOfDisplays = 3; break;
                    case "F6EC4EA5-AB18-4766-A5D6-F5B6E25A6BE8": numOfDisplays = 4; break;
                    case "5A4D815B-0E21-4279-8E98-4123BAFAFDD3": numOfDisplays = 5; break;
                    case "B5531C0E-B40D-493D-A236-BFDB3BD318C9": numOfDisplays = 6; break;
                    case "C424DC2A-8F28-4EE9-AE50-D2E6F76B4272": numOfDisplays = 7; break;
                    case "D8296633-8FA2-4FB3-B600-AE7B76433D59": numOfDisplays = 8; break;
                    case "47E813DE-4978-470F-8814-FC1B4F969BF8": numOfDisplays = 9; break;
                    case "AE418004-8B11-4056-A507-6051963F49D6": numOfDisplays = 10; break;
                    case "C1B137F2-4156-412C-89D3-BB7E506DC624": numOfDisplays = 11; break;
                    case "3CD398E4-4AC5-4482-BFD5-876C2CEB6BAD": numOfDisplays = 12; break;
                    case "330D2AE3-0021-497E-8400-F6B1591A4451": numOfDisplays = 13; break;
                    case "B9F36085-C854-4725-92A2-84634B12836A": numOfDisplays = 14; break;
                    case "8A11BA7A-95E1-46FE-8534-76FE4FBC9605": numOfDisplays = 15; break;
                    case "81A3B531-9159-4328-91E7-469504407548": numOfDisplays = 16; break;
                    case "418F34F4-D8B8-48D8-8793-EF3441C976DA": numOfDisplays = 17; break;
                    case "54BF317B-19A5-489B-AB0B-6060B07261A3": numOfDisplays = 18; break;
                    case "C8651224-E50F-4DCD-9AD4-9B844A47C55C": numOfDisplays = 19; break;
                    case "06077883-FA99-4210-8755-AC033DC0735D": numOfDisplays = 20; break;
                    case "D2515F33-A45F-40C5-B940-00C7D8FEA497": numOfDisplays = 100; break;
                    default: numOfDisplays = 100; break; //For demo set this to 100

                }//switch
                
                return numOfDisplays;
            }
            catch (Exception)
            {
                return 1;
            }           
            
        }//function

    }
}
