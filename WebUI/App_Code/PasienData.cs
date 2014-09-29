using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for PasienData
/// </summary>
public class PasienData
{
    public PasienData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string GetStatusName(int Status)
    {
        string result = "";
        switch (Status)
        {
            case -1:
                result = "Batal";
                break;
            case 0:
                result = "Pendaftaran";
                break;
            case 1:
                result = "Proses";
                break;
            case 2:
                result = "Rawat Inap";
                break;
            case 3:
                result = "Pulang";
                break;
            case 4:
                result = "Meninggal";
                break;
        }
        return result;
    }
}
