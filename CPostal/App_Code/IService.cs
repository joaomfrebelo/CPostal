using System;
using System.ServiceModel;
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
    RespCPostalList SearchByPostalCode(string cp, int limit, int offset, string key);

    /// <summary>
    /// Search an address by a partial address
    /// </summary>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    RespCPostalList SearchByAddress(string address, int limit, int offset, string key);

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
    RespCPostalList SearchAddressOfCounty(string county, string address, int limit, int offset, string key);

    /// <summary>
    /// search address in a district name
    /// </summary>
    /// <param name="county"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    RespCPostalList SearchByDisAddress(string county, string address, int limit, int offset, string key);

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
    RespCPostalList SearchByDisCouAddress(string district, string county, string address, int limit, int offset, string key);

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
    RespCPostalList SearchByDdCcAddress(string dd, string cc, string address, int limit, int offset, string key);

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
    RespCPostalList SearchByDdAddress(string dd, string address, int limit, int offset, string key);

    /// <summary>
    /// Search a client address
    /// </summary>
    /// <param name="client"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    RespCPostalList SerachByClient(string client, int limit, int offset, string key);

    /// <summary>
    /// Get a client address
    /// </summary>
    /// <param name="client"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
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
    RespCPostalList Search(String searchstring, int limit, int offset, string key);

    /// <summary>
    /// Get all districts
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    RespDistrictList GetAllDistrits(int limit, int offset, string key);

    /// <summary>
    /// Search district
    /// </summary>
    /// <param name="distrit"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    RespDistrictList SearchDistrit(string distrit, int limit, int offset, string key);

    /// <summary>
    /// Get district by id
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    RespDistrict GetDistrit(string dd, string key);

    /// <summary>
    /// Get all counties
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    RespCountyList GetAllCounties(int limit, int offset, string key);

    /// <summary>
    /// Serach counties
    /// </summary>
    /// <param name="county"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
    RespCountyList SearchCounty(string county, int limit, int offset, string key);

    /// <summary>
    /// Get county by id (county id and district id)
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="cc"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [OperationContract]
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
    RespCountyList SearchCountyOfDistrict(string dd, string county, int limit, int offset, string key);
    
}



