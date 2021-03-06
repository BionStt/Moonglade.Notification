# Moonglade.Notification (Preview)

[![Build status](https://dev.azure.com/ediwang/EdiWang-GitHub-Builds/_apis/build/status/Moonglade.Notification-CI)](https://dev.azure.com/ediwang/EdiWang-GitHub-Builds/_build/latest?definitionId=58)

.NET Core 3.1 Notification API used by my blog (https://edi.wang), runs on Microsoft Azure.

This API sets HTML template and send Email notifications to Blog administrator or users.

## Build and Run

> The following tools are required for development.

Tools | Alternative
--- | ---
[.NET Core 3.1 SDK](http://dot.net) | N/A
[Visual Studio 2019](https://visualstudio.microsoft.com/) | [Visual Studio Code](https://code.visualstudio.com/)
[Azure Key Vault](https://azure.microsoft.com/en-us/services/key-vault/) | N/A

### Setup Azure Key Vault and API App

> This API needs a pre-configured email account to send emaills. The account name and server infomations can be configured in appsettings.json or from environment variables. However, the password must be stored in Azure Key Vault to ensure security. Thus, you have to create an Azure Key Vault first.

You need to install Azure CLI and login to your Azure subscription first. See [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/?view=azure-cli-latest)

Open **"\Azure-Deployment-Script\Deploy.ps1"**

Replace these with your own values, and run the Powershell script:

```powershell
$subscriptionName = "Microsoft MVP"
$rsgName = "Moonglade-Test-RSG"
$regionName = "East Asia"
$keyVaultName = "Edi-Test-KV"
$pwdKey = "Notification-Email-Password"
$pwdValue = "P@ssw0rd"
$apiAppName = "moonglade-notification-test"
$aspName = "moonglade-test-plan"
$adminEmail = "edi.test@outlook.com"
$emailDisplayName = "Moonglade Notification Test"
$smtpServer = "smtp.whatever.com"
$smtpUserName = "admin"
```

### Build Source

1. Create an "**appsettings.Development.json**" under "**src\Moonglade.Notification.API**", this file defines development time settings. It is by default ignored by git, so you will need to manange it on your own.

2. Build and run **Moonglade.Notification.sln**

## Configuration

> Below section discuss system settings in **appsettings.[env].json**.

### Email Server

AppSettings section defines the email server configuration. Change the values as you need.

```json
"EnableEmailSending": true,
"EnableSsl": true,
"SmtpServerPort": 587,
"AdminEmail": "{AZURE-APPSVC-ENV}",
"EmailDisplayName": "{AZURE-APPSVC-ENV}",
"SmtpServer": "{AZURE-APPSVC-ENV}",
"SmtpUserName": "{AZURE-APPSVC-ENV}",
```

You can use Azure CLI to setup these values for App Service:

For example:

```bash
az webapp config appsettings set -g <Resource Group Name> -n <API App Name> --settings AppSettings:AdminEmail=<Admin Email>
```

### ApiKeys

You must assign owners and their API keys before you can call the API.

Define owners, roles, and API keys in AppSettings:ApiKeys

*Roles are currently not used, in the future, Administrators will have management APIs while users can only make notification requests.*

```json
"ApiKeys": [
  {
    "Id": 1,
    "Owner": "https-edi.wang",
    "Key": "{AZURE-APPSVC-ENV}",
    "Roles": [ "Administrators" ]
  }
```