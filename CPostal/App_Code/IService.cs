using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using joaomfrebelo.ptpostalcode;

[ServiceContract]
public interface IService
{
    /// <summary>
    /// Get the address for the postal code
    /// </summary>
    /// <param name="cp4"></param>
    /// <param name="cp3"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/GetPostalCode/{cp4}/{cp3}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespPostalCode GetPostalCode(string cp4, string cp3, string key);

    /// <summary>
    /// Serach a address of a partial postal code
    /// </summary>
    /// <param name="cp"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SearchByPostalCode/{cp}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCPostalList SearchByPostalCode(string cp, string limit, string offset, string key);

    /// <summary>
    /// Search an address by a partial address
    /// </summary>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SearchByAddress/{address}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCPostalList SearchByAddress(string address, string limit, string offset, string key);

    /// <summary>
    /// Search addren in a county name
    /// </summary>
    /// <param name="county"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SearchAddressOfCounty/{county}/{address}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCPostalList SearchAddressOfCounty(string county, string address, string limit, string offset, string key);

    /// <summary>
    /// search address in a district name
    /// </summary>
    /// <param name="district"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SearchByDisAddress/{district}/{address}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCPostalList SearchByDisAddress(string district, string address, string limit, string offset, string key);

    /// <summary>
    /// Search address in a county and distric name
    /// </summary>
    /// <param name="district"></param>
    /// <param name="county"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SearchByDisCouAddress/{district}/{county}/{address}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCPostalList SearchByDisCouAddress(string district, string county, string address, string limit, string offset, string key);

    /// <summary>
    /// Search address in a county id and district id
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="cc"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SearchByDdCcAddress/{dd}/{cc}/{address}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCPostalList SearchByDdCcAddress(string dd, string cc, string address, string limit, string offset, string key);

    /// <summary>
    /// search address in district id
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SearchByDdAddress/{dd}/{address}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCPostalList SearchByDdAddress(string dd, string address, string limit, string offset, string key);

    /// <summary>
    /// Search a client address
    /// </summary>
    /// <param name="client"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SerachByClient/{client}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCPostalList SerachByClient(string client, string limit, string offset, string key);

    /// <summary>
    /// Get a client address
    /// </summary>
    /// <param name="client"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/GetClient/{client}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespPostalCode GetClient(string client, string key);

    /// <summary>
    /// Custom search
    /// </summary>
    /// <param name="searchstring"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/Search/{searchstring}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCPostalList Search(String searchstring, string limit, string offset, string key);

    /// <summary>
    /// Get all districts
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/GetAllDistrits/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespDistrictList GetAllDistrits(string limit, string offset, string key);

    /// <summary>
    /// Search district
    /// </summary>
    /// <param name="distrit"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SearchDistrit/{distrit}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespDistrictList SearchDistrit(string distrit, string limit, string offset, string key);

    /// <summary>
    /// Get district by id
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/GetDistrit/{dd}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespDistrict GetDistrit(string dd, string key);

    /// <summary>
    /// Get all counties
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/GetAllCounties/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCountyList GetAllCounties(string limit, string offset, string key);

    /// <summary>
    /// Serach counties
    /// </summary>
    /// <param name="county"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SearchCounty/{county}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCountyList SearchCounty(string county, string limit, string offset, string key);

    /// <summary>
    /// Get county by id (county id and district id)
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="cc"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/GetCounty/{dd}/{cc}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCounty GetCounty(string dd, string cc, string key);

    /// <summary>
    /// Search county of a district id
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="county"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    [WebGet(UriTemplate = "/SearchCountyOfDistrict/{dd}/{county}/{limit}/{offset}/{key}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    RespCountyList SearchCountyOfDistrict(string dd, string county, string limit, string offset, string key);
    
}



