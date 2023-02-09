


<h1> Dating Api </h1>


<h2>Information</h2>


<p>
<h4>Api is still under development. I will implement DDD and CQRS in the near future<h4>
</p>

<p>

<h4>To run the api you need to create two files in path:<h4>


    +- DateApp
         +- secret.json
         +- app.config
    +- Server
        +- secret.json


<H4>secret.json (DateApp)</H4>

```
{
    "Google": {

        "ClientId": "clientId",
        "ClientSecret": "clientSecret"
    },
    "Paypal": {

        "PaypalEnvironment": "sandbox",
        "PayPalClientID": "paypalId",
        "PayPalSecret": "paypalSecret"
    },
    "ConnectionStrings": {

        "EntityCore": "Server=LOCAL ADRESS,PORT;Initial Catalog=DateAppDB;User Id=sa;Password=PASSWORD;Encrypt=false;",

        "Identity": "Server=LOCAL ADRESS,PORT;Initial Catalog=IdentityDB;User Id=sa;Password=PASSWORD;Encrypt=false;"
    }
}

```

<H4>secret.json (Server)</H4>

```
{
    "ConnectionString": {
        "connectionString": "Server=LOCAL ADRESS,PORT;Initial Catalog=IdentityDB;User Id=sa;Password=PASSWORD;Encrypt=false;"
    }
}

```


<H3>app.config</H3>

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
        <section name="paypal" type="PayPal.SDKConfigHandler, PayPal" />
    </configSections>

    <paypal>
        <settings>
            <add name="mode" value="sandbox" />
            <add name="clientId" value="clientId" />
            <add name="clientSecret" value="ClientSecret"/>
        </settings>
    </paypal>

</configuration>

```

</p>




<!-- CONTRIBUTING -->
## Contributing
<p>

<h4>If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch 
3. Commit your Changes 
4. Push to the Branch 
5. Open a Pull Request </h4>

</p>