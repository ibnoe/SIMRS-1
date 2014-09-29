using System;
using System.Configuration;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Xml;


/// <summary>
/// Summary description for Resource
/// </summary>
public class Resources
{
    public Resources()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
	///     Retrieves the RFC 1766 name of the current culture
	/// </summary>
	/// <remarks>
	///     This would more likely belong in an utility/global class, but for simplicities sake, I've put it here
	/// </remarks>
	public static string CurrentCultureName 
	{
		get { return System.Threading.Thread.CurrentThread.CurrentCulture.Name;}
	}

	/// <summary>
	///     Wrapper to GetString() to get a colon
	/// </summary>
	public static string Colon 
	{
		get { return GetString("","colon"); }
	}
	/// <summary>
	///     Returns 
	/// </summary>
	/// <param name="key" type="string">
	///     <para>
	///         The name of the resource we want
	///     </para>
	/// </param>
	/// <remarks>
	///   When in DEBUG mode, an ApplicationException will be thrown if the key isn't found
	/// </remarks>
	public static string GetString(string modulName, string key) 
	{
		Hashtable messages = GetResource(modulName);
		if (messages[key] == null)
		{
			messages[key] = "Resource value not found for key: " + key;
//				messages[key] = string.Empty;
//#if DEBUG
//				throw new ApplicationException("Resource value not found for key: " + key);
//#endif
		}
		return (string)messages[key];
	}

	private static Hashtable GetResource(string modulName) 
	{
		string currentCulture = CurrentCultureName;
		//string defaultCulture = LocalizationConfiguration.GetConfig().DefaultCultureName;
		string defaultCulture = CultureInfo.CurrentCulture.ToString();
		string cacheKey = "Localization:" + defaultCulture + ':' + modulName;
		if (HttpRuntime.Cache[cacheKey] == null)
		{
			Hashtable resource = new Hashtable();
        
			LoadResource(resource, modulName, defaultCulture, cacheKey);
			if (defaultCulture != currentCulture)
			{
				try
				{
					LoadResource(resource, modulName, currentCulture, cacheKey);
				} 
				catch (FileNotFoundException){}
			}
		}
		return (Hashtable)HttpRuntime.Cache[cacheKey];
	}

	private static void LoadResource(Hashtable resource, string modulName, string culture, string cacheKey) 
	{
		//string file = LocalizationConfiguration.GetConfig().LanguageFilePath + '\\' + culture + "\\Resource.xml";         
		modulName = modulName != "" ? modulName+"\\" :"";
        string file = ConfigurationManager.AppSettings["Main.Path"].ToString() + "Languages\\" + modulName + culture + ".xml";         
		XmlDocument xml = new XmlDocument();
		xml.Load(file);
		foreach (XmlNode n in xml.SelectSingleNode("Resource")) 
		{
			if (n.NodeType != XmlNodeType.Comment)
			{
				resource[n.Attributes["name"].Value] = n.InnerText;
			}
		}
		HttpRuntime.Cache.Insert(cacheKey, resource, new CacheDependency(file), DateTime.MaxValue, TimeSpan.Zero);
	}
  

	public static string GetTreeSpace(string levelId)
	{
		string stree = "";
		if (levelId == "1")
			stree = "\u2514\u00A0\u00A0"; 
		else if (levelId == "2")
			stree = "\u00A0\u00A0\u00A0\u00A0\u2514\u00A0\u00A0"; 
		else if (levelId == "3")
			stree = "\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u2514\u00A0\u00A0"; 
		else if (levelId == "4")
			stree = "\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u2514\u00A0\u00A0"; 
		else if (levelId == "5")
			stree = "\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u2514\u00A0\u00A0"; 
		else if (levelId == "6")
			stree = "\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u2514\u00A0\u00A0"; 
		else if (levelId == "7")
			stree = "\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u2514\u00A0\u00A0"; 
		else if (levelId == "8")
			stree = "\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u2514\u00A0\u00A0"; 
					
		return stree;
	}

    public static string Number2Word(long n)
    {
        string TempKata;
        string[] Sat = new string[] {" ", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas"};

        if(n <= 11)
            TempKata = " " + Sat[n];
        else if( n > 11 && n <= 19)
            TempKata = Number2Word(n % 10) + " Belas";
        else if (n >= 20 && n < 100)
            TempKata = Number2Word(n / 10) + " Puluh" + Number2Word(n % 10);
        else if (n >= 100 && n < 200)
            TempKata = " Seratus" + Number2Word(n - 100);
        else if (n >= 200 && n < 1000)
            TempKata = Number2Word(n / 100) + " Ratus" + Number2Word(n % 100);
        else if (n >= 1000 && n < 2000)
            TempKata = " Seribu" + Number2Word(n - 1000);
        else if (n >= 2000 && n < 1000000)
            TempKata = Number2Word(n / 1000) + " Ribu" + Number2Word(n % 1000) ;
        else if (n >= 1000000 && n < 1000000000)
            TempKata = Number2Word(n / 1000000) + " Juta" + Number2Word(n % 1000000);
        else 
            TempKata = Number2Word(n / 1000000000) + " Milyar" + Number2Word(n % 1000000000);
        
        return TempKata;
    }

}
