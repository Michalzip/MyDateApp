  <h1 align="center">Dating Api </h1>

  <p align="center">
  <h3 align="center">  Here you will find out how api looking and how you will use!</h3>
    <br />

<p align="center">
  <img src="https://github.com/MichalZip/MyDateApp/Images/DateApp-Screen.jpg" width="250" height="420" />   
 
  <img src="https://github.com/MichalZip/MyDateApp/Images/IdentityServer-Screen.jpg" width="250" height="420" />

</p>

<!-- ABOUT THE PROJECT -->

## About The Project :sunglasses:

Thanks to our amazing dating app API, you could be lucky enough to meet your other half out of the many people on our platform :smile:

<br/>

<!-- GETTING STARTED -->

## Getting Started

<p>The project includes two microservices that communicate with each other using RabbitMQ queues.</br>
IdentityServer -  which is responsible for authenticating your identity and performing all types of operations on the IdentityDb </br>
DateApp -  which handles messages, likes, user profiles, and all types of operations on the DateAppDb
</a></p>

### Prerequisites

<br>RabbitMQ</br>

<p>install rabbitMQ in docker</p>

        docker pull rabbitmq:3-management
        docker run --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management

<br>Dotnet </br>

        dotnet restore
        dotnet run

<br>Docker</br>

        docker-compose build
        docker-compose up

<br>create files in path:</br>

```
 +- DateApp
    +- DateApp.Application
       +- Configs
          +- secret.json <- add file
          +- app.config <- add file


    +- Server
       +- Server.Application
          +- Configs
             +- secret.json <- add file


```

<H4>secret.json (DateApp)</H4>

```
{
    "ConnectionStrings": {

        "EntityCore": "Server=LOCAL ADRESS,PORT;Initial Catalog=DateAppDB;User Id=sa;Password=PASSWORD;Encrypt=false;",
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

<H4>app.config</H4>

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

After these steps, first enable rabbitMq in docker and wait a while before starting microservices

<!-- CONTRIBUTING -->

## Contributing

If you have a suggestion that would make this better, please fork the repo and create a pull request or repoirt it here <a href="https://github.com/Michalzip/MyDateApp/issues">link</a>. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch
3. Commit your Changes
4. Push to the Branch
5. Open a Pull Request
