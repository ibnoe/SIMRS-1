using System;
using System.Configuration;
using System.Collections;
using System.Globalization;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using System.Xml;

/// <summary>
/// Summary description for DataReferensi
/// </summary>
public class DataReferensi
{
    public DataReferensi()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region # GET DATA REFERENSI PROPINSI

    public static DataTable GetPropinsiData()
    {
        string cacheKey = "SIMRS_Propinsi";
        if (HttpRuntime.Cache[cacheKey] == null)
        {
            BkNet.DataAccess.Propinsi myObj = new BkNet.DataAccess.Propinsi();
            DataTable objData = myObj.GetList();
            HttpRuntime.Cache.Insert(cacheKey, objData);
        }
        return (DataTable)HttpRuntime.Cache[cacheKey];
    }
    public static string GetPropinsiFunction(string action, string option)
    {
        DataTable Data = GetPropinsiData();
        string textOption = Resources.GetString("Referensi", "SelectAll");
        string textOptionKab = Resources.GetString("Referensi", "SelectAll");
        if (option.ToUpper() == "SELECT")
        {
            textOption = Resources.GetString("Referensi", "SelectProp");
            textOptionKab = Resources.GetString("Referensi", "SelectKab");
        }
        string jsFunction = "";
        //Draw Function 
        jsFunction += "<script language=\"javascript\" type=\"text/javascript\">";
        jsFunction += "\n var propinsidata = new Array; \n";

        int k = 0;
        jsFunction += "\n propinsidata[" + k + "] = new Array( '','','');";
        foreach (DataRow dr in Data.Rows)
        {
            k++;
            jsFunction += "\n propinsidata[" + k + "] = new Array( '" + dr["Id"].ToString() + "','" + dr["Kode"].ToString() + "','" + dr["Nama"].ToString() + "');";
        }
        jsFunction += "\n\n function ChangePropinsiList( propinsidata, listname ,source, key, orig_key, orig_val, display, option) { ";
        jsFunction += "\n		var list = document.getElementById(listname); ";
        jsFunction += "\n		for (i in list.options.length) { ";
        jsFunction += "\n 			list.options[i] = null; ";
        jsFunction += "\n		} ";
        jsFunction += "\n		i = 0; ";
        jsFunction += "\n		for (x in source) { ";
        jsFunction += "\n 			if (source[x][0] == key) { ";
        jsFunction += "\n 				opt = new Option(); ";
        jsFunction += "\n 				opt.value = source[x][1]; ";
        jsFunction += "\n 				if(source[x][1] == ''){ ";
        jsFunction += "\n 					opt.text = '" + textOptionKab + "' ; ";
        jsFunction += "\n 				}else {";
        jsFunction += "\n 					if(display.toUpperCase() == 'CODE') ";
        jsFunction += "\n 						opt.text = source[x][2]; ";
        jsFunction += "\n 					else if(display.toUpperCase() == 'NAME') ";
        jsFunction += "\n 						opt.text = source[x][3]; ";
        jsFunction += "\n 					else ";
        jsFunction += "\n 						opt.text = source[x][2] + ' ['+source[x][3]+ ']'; ";
        jsFunction += "\n 				} ";
        jsFunction += "\n 				if ((orig_key == key && orig_val == opt.value) || i == 0) { ";
        jsFunction += "\n 					opt.selected = true; ";
        jsFunction += "\n 				} ";
        jsFunction += "\n 				list.options[i++] = opt; ";
        jsFunction += "\n 			} ";
        jsFunction += "\n		} ";
        jsFunction += "\n		if (i == 0) { ";
        jsFunction += "\n 			opt = new Option(); ";
        jsFunction += "\n 			opt.value = ''; ";
        jsFunction += "\n 			opt.text = '" + textOptionKab + "' ; ";
        jsFunction += "\n			list.options[i++] = opt; ";
        jsFunction += "\n		} ";
        jsFunction += "\n		list.length = i; ";

        if (action.ToUpper() == "FILTER")
        {
            jsFunction += "\n		for (y in propinsidata) { ";
            jsFunction += "\n 			if (propinsidata[y][0] == key) { ";
            jsFunction += "\n 				document.getElementById('PropinsiNama').value = propinsidata[y][2] ; ";
            jsFunction += "\n 				break; ";
            jsFunction += "\n 			} ";
            jsFunction += "\n		} ";
        }
        jsFunction += "\n		ChangeKabupatenKotaList( kabupatenkotadata, 'LokasiId' ,lokasidata, list.options[list.selectedIndex].value, 0, 0, display, option,''); ";
        jsFunction += "\n	} ";
        jsFunction += "\n</script>";

        return jsFunction;
    }

    public static string DrawPropinsiList(string PropinsiId)
    {
        string display = "";
        string action = "Filter";
        string option = "SelectAll";
        return DrawPropinsiList(PropinsiId, display, action, option);
    }

    public static string DrawPropinsiList(string PropinsiId, string display)
    {
        string action = "";
        string option = "SelectAll";
        return DrawPropinsiList(PropinsiId, display, action, option);
    }
    public static string DrawPropinsiList(string PropinsiId, string display, string action)
    {
        string option = "SelectAll";
        return DrawPropinsiList(PropinsiId, display, action, option);
    }
    public static string DrawPropinsiList(string PropinsiId, string display, string action, string option)
    {
        DataTable dt = GetPropinsiData();
        DataView dv = dt.DefaultView;
        if (display.ToUpper() == "NAME")
            dv.Sort = " Nama ASC";
        else
            dv.Sort = " Kode ASC";
        string jscript = "";
        jscript = "onchange=\"ChangePropinsiList( propinsidata, 'KabupatenKotaId',kabupatenkotadata, document.getElementById('PropinsiId').options[document.getElementById('PropinsiId').selectedIndex].value, 0, 0,'" + display + "','" + option + "');\"";
        string textOption = Resources.GetString("Referensi", "SelectAll");
        if (option.ToUpper() == "SELECT")
        {
            textOption = Resources.GetString("Referensi", "SelectProp");
        }
        string itemText = "";
        string itemNama = "";
        string listData = "";
        listData += "\n <SELECT id=\"PropinsiId\" name=\"PropinsiId\" " + jscript + ">";
        listData += "\n <OPTION value=\"\">" + textOption + "</OPTION>";
        for (int k = 0; k < dv.Count; k++)
        {
            if (display.ToUpper() == "CODE")
                itemText = dv[k]["Kode"].ToString();
            else if (display.ToUpper() == "NAME")
                itemText = dv[k]["Nama"].ToString();
            else
                itemText = dv[k]["Kode"].ToString() + " [" + dv[k]["Nama"].ToString() + "]";

            if (dv[k]["Id"].ToString() == PropinsiId.ToString())
            {
                itemNama = dv[k]["Nama"].ToString();
                listData += "\n <OPTION value=\"" + dv[k]["Id"].ToString() + "\" selected>" + itemText + "</OPTION>";
            }
            else
            {
                listData += "\n <OPTION value=\"" + dv[k]["Id"].ToString() + "\">" + itemText + "</OPTION>";
            }
        }
        listData += "</SELECT>";
        if (action.ToUpper() == "FILTER")
        {
            listData += "<input type=\"hidden\" name=\"PropinsiNama\" id=\"PropinsiNama\" value=\"" + itemNama + "\" >";
        }
        return listData;
    }


    #endregion

    #region #GET DATA REFERENSI KABUPATEN/KOTA
    public static DataTable GetKabupatenKotaData()
    {
        string cacheKey = "SIMRS_KabupatenKota";
        if (HttpRuntime.Cache[cacheKey] == null)
        {
            BkNet.DataAccess.KabupatenKota myObj = new BkNet.DataAccess.KabupatenKota();
            DataTable objData = myObj.SelectAll();
            HttpRuntime.Cache.Insert(cacheKey, objData);
        }
        return (DataTable)HttpRuntime.Cache[cacheKey];
    }

    public static string GetKabupatenKotaFunction(string display, string action, string option, string displayLokasi)
    {
        DataTable dt = GetKabupatenKotaData();
        DataView dv = dt.DefaultView;
        dv.Sort = " PropinsiId ASC ";
        if (display.ToUpper() == "NAME")
            dv.Sort += ", Nama ASC";
        else
            dv.Sort += ", Kode ASC";
        string textOption = Resources.GetString("Referensi", "SelectAll");
        string textOptionLok = Resources.GetString("Referensi", "SelectAll");
        if (option.ToUpper() == "SELECT")
        {
            textOption = Resources.GetString("Referensi", "SelectKab");
            textOptionLok = Resources.GetString("Referensi", "SelectLokasi");
        }
        string jsFunction = "";
        //Draw Function 
        jsFunction += "<script language=\"javascript\" type=\"text/javascript\">";
        jsFunction += "\n var kabupatenkotadata = new Array; \n";

        int k = 0;
        string OldParentId = "";
        string NewParentId = "";
        jsFunction += "\n kabupatenkotadata[" + k + "] = new Array( '" + NewParentId + "','','','');";
        k++;
        for (int i = 0; i < dv.Count; i++)
        {
            NewParentId = dv[i]["PropinsiId"].ToString();
            if (NewParentId != OldParentId)
            {
                jsFunction += "\n kabupatenkotadata[" + k + "] = new Array( '" + NewParentId + "','','','');";
                k++;
            }
            jsFunction += "\n kabupatenkotadata[" + k + "] = new Array( '" + dv[i]["PropinsiId"].ToString() + "','" + dv[i]["Id"].ToString() + "','" + dv[i]["Kode"].ToString() + "','" + dv[i]["Nama"].ToString() + "');";
            k++;
            OldParentId = NewParentId;
        }

        jsFunction += "\n\n function ChangeKabupatenKotaList( kabupatenkotadata, listname ,source, key, orig_key, orig_val, display, option,displayLokasi) { ";
        jsFunction += "\n		var list = document.getElementById(listname); ";
        jsFunction += "\n		for (i in list.options.length) { ";
        jsFunction += "\n 			list.options[i] = null; ";
        jsFunction += "\n		} ";
        jsFunction += "\n		i = 0; ";
        jsFunction += "\n		for (x in source) { ";
        jsFunction += "\n 			if (source[x][0] == key) { ";
        jsFunction += "\n 				opt = new Option(); ";
        jsFunction += "\n 				opt.value = source[x][1]; ";
        jsFunction += "\n 				if(source[x][1] == ''){ ";
        jsFunction += "\n 					opt.text = '" + textOptionLok + "' ; ";
        jsFunction += "\n 				}else {";
        jsFunction += "\n 					if(displayLokasi.toUpperCase() == 'CODE') ";
        jsFunction += "\n 						opt.text = source[x][2]; ";
        jsFunction += "\n 					else if(displayLokasi.toUpperCase() == 'NAME') ";
        jsFunction += "\n 						opt.text = source[x][3]; ";
        jsFunction += "\n 					else ";
        jsFunction += "\n 						opt.text = source[x][2] + ' ['+source[x][3]+ ']'; ";
        jsFunction += "\n 				} ";
        jsFunction += "\n 				if ((orig_key == key && orig_val == opt.value) || i == 0) { ";
        jsFunction += "\n 					opt.selected = true; ";
        jsFunction += "\n 				} ";
        jsFunction += "\n 				list.options[i++] = opt; ";
        jsFunction += "\n 			} ";
        jsFunction += "\n		} ";
        jsFunction += "\n		if (i == 0) { ";
        jsFunction += "\n 			opt = new Option(); ";
        jsFunction += "\n 			opt.value = ''; ";
        jsFunction += "\n 			opt.text = '" + textOptionLok + "' ; ";
        jsFunction += "\n			list.options[i++] = opt; ";
        jsFunction += "\n		} ";
        jsFunction += "\n		list.length = i; ";

        if (action.ToUpper() == "FILTER")
        {
            jsFunction += "\n		for (y in kabupatenkotadata) { ";
            jsFunction += "\n 			if (kabupatenkotadata[y][1] == key) { ";
            jsFunction += "\n 				document.getElementById('KabupatenKotaNama').value = kabupatenkotadata[y][3] ; ";
            jsFunction += "\n 				break; ";
            jsFunction += "\n 			} ";
            jsFunction += "\n		} ";
        }
        if (action.ToUpper() == "FORMATKODE")
        {
            jsFunction += "\n		ChangeFormatLokasiAset(list.options[list.selectedIndex].value , lokasidata, 'KodeLokasi');";
        }
        jsFunction += "\n	} ";

        jsFunction += "\n</script>";
        return jsFunction;
    }


    public static string DrawKabupatenKotaList()
    {
        string PropinsiId = "";
        string KabupatenKotaId = "";
        string display = "";
        string action = "";
        string option = "SelectAll";
        string displayLokasi = "";
        return DrawKabupatenKotaList(PropinsiId, KabupatenKotaId, display, action, option, displayLokasi);
    }
    public static string DrawKabupatenKotaList(string PropinsiId)
    {
        string KabupatenKotaId = "";
        string display = "";
        string action = "";
        string option = "SelectAll";
        string displayLokasi = "";
        return DrawKabupatenKotaList(PropinsiId, KabupatenKotaId, display, action, option, displayLokasi);
    }
    public static string DrawKabupatenKotaList(string PropinsiId, string KabupatenKotaId)
    {
        string display = "";
        string action = "";
        string option = "SelectAll";
        string displayLokasi = "";
        return DrawKabupatenKotaList(PropinsiId, KabupatenKotaId, display, action, option, displayLokasi);
    }
    public static string DrawKabupatenKotaList(string PropinsiId, string KabupatenKotaId, string display)
    {
        string action = "";
        string option = "SelectAll";
        string displayLokasi = "";
        return DrawKabupatenKotaList(PropinsiId, KabupatenKotaId, display, action, option, displayLokasi);
    }
    public static string DrawKabupatenKotaList(string PropinsiId, string KabupatenKotaId, string display, string action)
    {
        string option = "SelectAll";
        string displayLokasi = "";
        return DrawKabupatenKotaList(PropinsiId, KabupatenKotaId, display, action, option, displayLokasi);
    }
    public static string DrawKabupatenKotaList(string PropinsiId, string KabupatenKotaId, string display, string action, string option)
    {
        string displayLokasi = "";
        return DrawKabupatenKotaList(PropinsiId, KabupatenKotaId, display, action, option, displayLokasi);
    }
    public static string DrawKabupatenKotaList(string PropinsiId, string KabupatenKotaId, string display, string action, string option, string displayLokasi)
    {
        BkNet.DataAccess.KabupatenKota obj = new BkNet.DataAccess.KabupatenKota();
        if (PropinsiId != "")
            obj.PropinsiId = int.Parse(PropinsiId);
        DataTable dt = obj.GetListWPropinsiIdLogic();
        DataView dv = dt.DefaultView;
        if (display.ToUpper() == "NAME")
            dv.Sort = " Nama ASC";
        else
            dv.Sort = " Kode ASC";
        string jscript = "";
        jscript = "onchange=\"ChangeKabupatenKotaList( kabupatenkotadata, 'LokasiId',lokasidata, document.getElementById('KabupatenKotaId').options[document.getElementById('KabupatenKotaId').selectedIndex].value, 0, 0,'" + display + "','" + option + "','" + displayLokasi + "');\"";
        string textOption = Resources.GetString("Referensi", "SelectAll");
        if (option.ToUpper() == "SELECT")
        {
            textOption = Resources.GetString("Referensi", "SelectKab");
        }
        string itemText = "";
        string itemNama = "";
        string listData = "";
        listData += "\n <SELECT id=\"KabupatenKotaId\" name=\"KabupatenKotaId\" " + jscript + ">";
        listData += "\n <OPTION value=\"\">" + textOption + "</OPTION>";
        for (int k = 0; k < dv.Count; k++)
        {
            if (display.ToUpper() == "CODE")
                itemText = dv[k]["Kode"].ToString();
            else if (display.ToUpper() == "NAME")
                itemText = dv[k]["Nama"].ToString();
            else
                itemText = dv[k]["Kode"].ToString() + " [" + dv[k]["Nama"].ToString() + "]";

            if (dv[k]["Id"].ToString() == KabupatenKotaId.ToString())
            {
                itemNama = dv[k]["Nama"].ToString();
                listData += "\n <OPTION value=\"" + dv[k]["Id"].ToString() + "\" selected>" + itemText + "</OPTION>";
            }
            else
            {
                listData += "\n <OPTION value=\"" + dv[k]["Id"].ToString() + "\">" + itemText + "</OPTION>";
            }
        }
        listData += "</SELECT>";
        if (action.ToUpper() == "FILTER")
        {
            listData += "<input type=\"hidden\" name=\"KabupatenKotaNama\" id=\"KabupatenKotaNama\" value=\"" + itemNama + "\" >";
        }
        return listData;
    }

    #endregion
}
