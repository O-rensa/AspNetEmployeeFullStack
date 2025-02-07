## Prerequisites

I will be listing the version of sdks/softwares that I have on my machine. I haven't tried to run this on other versions.

- Dotnet sdk version 8.0.4. Available to download [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
- Node version 22.13.1. Available to download [here](https://nodejs.org/en).
- Microsof SQL Server 2022 Developer. Available to download [here](https://www.microsoft.com/en/sql-server/sql-server-downloads).
- Git. Available to download [here](https://git-scm.com/downloads).
- Visual Studio 2022 Community Edition(Optional). Available to download [here](https://visualstudio.microsoft.com/free-developer-offers/).

## How to run?

1. Open a directory of where you want to clone and open the terminal. Then run
   
   ```
   git clone https://github.com/O-rensa/AspNetEmployeeFullStack.git
   ```
   
2. Go inside the project by running

   ```
   cd AspNetEmployeeFullStack
   ```

3. Consider this as your Root Working Directory(RWD).

### Run the back-end server 

#### (via terminal)

1. Get your MSSQL Connection String and open `RWD/back-end/Employee.Api/appsettings.Development.json` with your editor.
2. Paste your MSSQL Connection String here:

![Screenshot1](https://i.postimg.cc/pLfrvSgw/Screenshot-2025-02-07-165934.png)

3. From Root Working directory, open a terminal and run the following

```
  cd back-end
```
- run the server
```
  dotnet run --project Employee.Api/Employee.Api.csproj --launch-profile http
```

4. Open `http://localhost:5069/` on your browser to confirm that it is running. Do not close the terminal to keep the back-end server running.

#### (via Visual Studio 2022 Community Edition)

1. Run Visual Studio 2022 Community Edition and open `RWD/back-end/back-end.sln`.
2. Open the `Employee.Api` Project and edit `appsettings.Development.json`.
3. Get your MSSQL Connection String and paste it here.

![Screenshot1](https://i.postimg.cc/pLfrvSgw/Screenshot-2025-02-07-165934.png)

4. Choose the `http` Profile and press F5 on your keyboard.

#### Run the front-end app

1. From Root Working directory, open another terminal and run the following.

```
  cd front-end
```
- install the required packages
```
  npm install
```
- run the application
```
  npm run start
```

2. Open `http://localhost:4200/` on your browser.
