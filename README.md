# PTpostalcode
### CSharp and MySql WCF web service server SOAP/RESTfull for portuguese postal code and address

## Introduction

A WCF SOAP/RESTfull web server where you can search for portuguese postal code and address

## SOAP Example

Endopoint
http://yourservicedomain/Service.svc/soap

1) To get a address of a postal code 

```
SOAP Body:

<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">
   <soapenv:Header/>
   <soapenv:Body>
      <tem:GetPostalCode>
         <!--Optional:-->
         <tem:cp4>2635</tem:cp4>
         <!--Optional:-->
         <tem:cp3>302</tem:cp3>
         <!--Optional:-->
         <tem:key>free</tem:key>
      </tem:GetPostalCode>
   </soapenv:Body>
</soapenv:Envelope>

```

2) To get a address of a postal code

```
SOAP Body:

<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">
   <soapenv:Header/>
   <soapenv:Body>
      <tem:GetPostalCode>
         <!--Optional:-->
         <tem:cp4>2635</tem:cp4>
         <!--Optional:-->
         <tem:cp3>302</tem:cp3>
         <!--Optional:-->
         <tem:key>free</tem:key>
      </tem:GetPostalCode>
   </soapenv:Body>
</soapenv:Envelope>

```
## RESTfull Example
```
1) Search an address
```

http://yourservicedomain/Service.svc/rest/SearchByAddress/est%20pombal/100/0/free

```

1) Get the address of a postal code
```
http://yourservicedomain/Service.svc/rest/Service.svc/rest/GetPostalCode/2635/302/free

```

## Available methods

- GetPostalCode(string cp4, string cp3, string key);
- SearchByPostalCode(string cp, string limit, string offset, string key);
- SearchByAddress(string address, string limit, string offset, string key);
- SearchAddressOfCounty(string county, string address, string limit, string offset, string key);
- SearchByDisAddress(string district, string address, string limit, string offset, string key);
- SearchByDisCouAddress(string district, string county, string address, string limit, string offset, string key);
- SearchByDdCcAddress(string dd, string cc, string address, string limit, string offset, string key);
- SearchByDdAddress(string dd, string address, string limit, string offset, string key);
- SerachByClient(string client, string limit, string offset, string key);
- GetClient(string client, string key);
- Search(String searchstring, string limit, string offset, string key);
- GetAllDistrits(string limit, string offset, string key);
- SearchDistrit(string distrit, string limit, string offset, string key);
- GetDistrit(string dd, string key);
- GetAllCounties(string limit, string offset, string key);
- SearchCounty(string county, string limit, string offset, string key);
- GetCounty(string dd, string cc, string key);
- SearchCountyOfDistrict(string dd, string county, string limit, string offset, string key);

## License
PTpostalcode is GNU General Public License (GPL)

This program is distributed in the hope that it will be useful, but without any warranty; without even the implied warranty of merchantabilty or fitness for a particular purpose. See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see <http://www.gnu.org/licenses/>.
