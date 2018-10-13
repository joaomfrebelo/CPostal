using joaomfrebelo.ptpostalcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


public class Service : IService
{
    /// <summary>
    /// Get a client
    /// </summary>
    /// <param name="client"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespPostalCode GetClient(string client, string key)
    {
        try
        {
            RespPostalCode r = Auth.GetRespCPostalAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> ld = CPostal.GetClient(client);

            if (ld.Count == 0)
            {
                CPostal c = new CPostal();
                r.Cpostal = c;
                r.SetStatus(Response.EStatus.ERROR);
                r.error = string.Format("Record not found, cliente = {0}", client);
            }
            else
            {
                r.Cpostal = ld[0];
            }
            return r;
        }
        catch (Exception e)
        {
            RespPostalCode r = new RespPostalCode();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Get from a postal code
    /// </summary>
    /// <param name="cp4"></param>
    /// <param name="cp3"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespPostalCode GetPostalCode(string cp4, string cp3, string key)
    {
        try
        {
            RespPostalCode r = Auth.GetRespCPostalAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> lc = CPostal.GetCPostal(cp4, cp3);

            if (lc.Count == 0)
            {
                CPostal c = new CPostal();
                r.Cpostal = c;
                r.SetStatus(Response.EStatus.ERROR);
                r.error = string.Format("Record not found, cp3 = {0} e cp4 = {1}", cp4, cp3);
            }
            else
            {
                r.Cpostal = lc[0];
            }
            return r;
        }
        catch (Exception e)
        {
            RespPostalCode r = new RespPostalCode();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    public RespCPostalList Search(string searchstring, int limit, int offset, string key)
    {
        try
        {
            RespCPostalList r = Auth.GetRespCPostalListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> lc = CPostal.Search(searchstring, limit, offset);

            r.Cpostal = lc;

            return r;
        }
        catch (Exception e)
        {
            RespCPostalList r = new RespCPostalList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Search an address
    /// </summary>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCPostalList SearchByAddress(string address, int limit, int offset, string key)
    {
        try
        {
            RespCPostalList r = Auth.GetRespCPostalListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> lc = CPostal.SearchByAddress(address, limit, offset);

            r.Cpostal = lc;

            return r;
        }
        catch (Exception e)
        {
            RespCPostalList r = new RespCPostalList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Search address of coounty name
    /// </summary>
    /// <param name="county"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCPostalList SearchAddressOfCounty(string county, string address, int limit, int offset, string key)
    {
        try
        {
            RespCPostalList r = Auth.GetRespCPostalListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> lc = CPostal.SearchAddressOfCounty(county, address, limit, offset);

            r.Cpostal = lc;

            return r;
        }
        catch (Exception e)
        {
            RespCPostalList r = new RespCPostalList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Search address by a postal code
    /// </summary>
    /// <param name="cp"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCPostalList SearchByPostalCode(string cp, int limit, int offset, string key)
    {
        try
        {
            RespCPostalList r = Auth.GetRespCPostalListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> lc = CPostal.SearchByCpostal(cp, limit, offset);

            r.Cpostal = lc;

            return r;
        }
        catch (Exception e)
        {
            RespCPostalList r = new RespCPostalList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Search by address
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCPostalList SearchByDdAddress(string dd, string address, int limit, int offset, string key)
    {
        try
        {
            RespCPostalList r = Auth.GetRespCPostalListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> lc = CPostal.SearchByDdAddress(dd, address, limit, offset);

            r.Cpostal = lc;

            return r;
        }
        catch (Exception e)
        {
            RespCPostalList r = new RespCPostalList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Search by county id, district id an address
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="cc"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCPostalList SearchByDdCcAddress(string dd, string cc, string address, int limit, int offset, string key)
    {
        try
        {
            RespCPostalList r = Auth.GetRespCPostalListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> lc = CPostal.SearchByDdAddress(dd, cc, address, limit, offset);

            r.Cpostal = lc;

            return r;
        }
        catch (Exception e)
        {
            RespCPostalList r = new RespCPostalList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Search address of a district name
    /// </summary>
    /// <param name="district"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCPostalList SearchByDisAddress(string district, string address, int limit, int offset, string key)
    {
        try
        {
            RespCPostalList r = Auth.GetRespCPostalListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> lc = CPostal.SearchByDisAddress(district, address, limit, offset);

            r.Cpostal = lc;

            return r;
        }
        catch (Exception e)
        {
            RespCPostalList r = new RespCPostalList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Search by distric and county name
    /// </summary>
    /// <param name="district"></param>
    /// <param name="county"></param>
    /// <param name="address"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCPostalList SearchByDisCouAddress(string district, string county, string address, int limit, int offset, string key)
    {
        try
        {
            RespCPostalList r = Auth.GetRespCPostalListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> lc = CPostal.SearchByDisConAddress(district, county, address, limit, offset);

            r.Cpostal = lc;

            return r;
        }
        catch (Exception e)
        {
            RespCPostalList r = new RespCPostalList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }
    /// <summary>
    /// Search a client
    /// </summary>
    /// <param name="client"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCPostalList SerachByClient(string client, int limit, int offset, string key)
    {
        try
        {
            RespCPostalList r = Auth.GetRespCPostalListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<CPostal> lc = CPostal.SerachByCliente(client, limit, offset);

            r.Cpostal = lc;

            return r;
        }
        catch (Exception e)
        {
            RespCPostalList r = new RespCPostalList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Get al district
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespDistrictList GetAllDistrits(int limit, int offset, string key)
    {
        try
        {
            RespDistrictList r = Auth.GetRespDistrictListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            r.District = District.GetAll(limit, offset);
            return r;
        }
        catch (Exception e)
        {
            RespDistrictList r = new RespDistrictList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Search district
    /// </summary>
    /// <param name="district"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespDistrictList SearchDistrit(string district, int limit, int offset, string key)
    {
        try
        {
            RespDistrictList r = Auth.GetRespDistrictListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            r.District = District.SearchDistrict(district, limit, offset);
            return r;
        }
        catch (Exception e)
        {
            RespDistrictList r = new RespDistrictList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Get a distric by id
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespDistrict GetDistrit(string dd, string key)
    {
        try
        {
            RespDistrict r = Auth.GetRespDistrictAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<District> ld = District.GetDistrict(dd, 1, 0, key);

            if (ld.Count == 0)
            {
                District d = new District();
                d.dd = "";
                d.district = "";
                r.district = d;
                r.SetStatus(Response.EStatus.ERROR);
                r.error = string.Format("Record not found, district dd = {0}", dd);
            }
            else
            {
                r.district = ld[0];
            }
            return r;
        }
        catch (Exception e)
        {
            RespDistrict r = new RespDistrict();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Get all counties
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCountyList GetAllCounties(int limit, int offset, string key)
    {
        try
        {
            RespCountyList r = Auth.GetRespCountyListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            r.County = County.GetAll(limit, offset);
            return r;
        }
        catch (Exception e)
        {
            RespCountyList r = new RespCountyList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Get county by name
    /// </summary>
    /// <param name="coounty"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCountyList SearchCounty(string coounty, int limit, int offset, string key)
    {
        try
        {
            RespCountyList r = Auth.GetRespCountyListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            r.County = County.SearchCounty(coounty, limit, offset);
            return r;
        }
        catch (Exception e)
        {
            RespCountyList r = new RespCountyList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    public RespCounty GetCounty(string dd, string cc, string key)
    {
        try
        {
            RespCounty r = Auth.GetRespCountyAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            List<County> ld = County.GetCounty(dd, cc, 1, 0);

            if (ld.Count == 0)
            {
                County c = new County();
                c.dd = "";
                c.district = "";
                c.cc = "";
                c.county = "";
                r.County = c;
                r.SetStatus(Response.EStatus.ERROR);
                r.error = string.Format("Record not found, county cc = {0}", cc);
            }
            else
            {
                r.County = ld[0];
            }
            return r;
        }
        catch (Exception e)
        {
            RespCounty r = new RespCounty();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }

    /// <summary>
    /// Search county of a distric id
    /// </summary>
    /// <param name="dd"></param>
    /// <param name="county"></param>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public RespCountyList SearchCountyOfDistrict(string dd, string county, int limit, int offset, string key)
    {
        try
        {
            RespCountyList r = Auth.GetRespCountyListAuth4Key(key);

            if (r.EqualsEStatus(r.GetStatus(), Response.EStatus.ERROR))
            {
                return r;
            }

            r.County = County.SearchCountyOfDistrict(dd, county, limit, offset);
            return r;
        }
        catch (Exception e)
        {
            RespCountyList r = new RespCountyList();
            r.SetStatus(Response.EStatus.ERROR);
            r.error = e.Message;
            return r;
        }
    }
    
}

