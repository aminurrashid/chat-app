**Dev environment setup prerequisite:**

 - Visual Studio ([download link](https://visualstudio.microsoft.com/vs/)) ([setup guide](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2019))
 - Visual Studio Code ([download link](https://code.visualstudio.com/)) ([setup guide](https://code.visualstudio.com/docs/setup/windows))
 - MS SQL Server developer edition with management studio ([download link](https://go.microsoft.com/fwlink/?linkid=866662)) ([setup guide](https://social.technet.microsoft.com/wiki/contents/articles/52734.sql-server-2019-step-by-step-installation.aspx))
 - npm ([download link](https://www.npmjs.com/get-npm)) ([setup guide](https://phoenixnap.com/kb/install-node-js-npm-on-windows))
 - Angular CLI ([setup guide](https://angular.io/guide/setup-local#install-the-angular-cli)) (**Note:** npm need to be installed before this)

Before proceeding further, please download and install these prerequisites if not already installed on your machine.

**Setup & build instructions:**

**a. Database preparation:**

 1. Open provided "db_schema.sql" script file from db folder using MS SQL Server management studio (double clicking the "db_script.sql" script file will open it in MS SQL Server management studio).
 2. Execute the script (see screenshot below).
 [![db-script-run.jpg](https://i.postimg.cc/85CjFZTj/db-script-run.jpg)](https://postimg.cc/7CpxdMGk)

After the excution has been completed, required database along with tables will be created in MS SQL Server.

**b. API server setup & run:**

 - Go to "SignalRServer" folder.
 - Open the "SignalRServer.sln" file in Visual Studio (double clicking the "SignalRServer.sln" file will open it in Visual Studio).
 - Run the application by clicking Execute button (see screenshot below), this should start the api server and signalR hub.
 [![api-server-run.jpg](https://i.postimg.cc/yY33XpcR/api-server-run.jpg)](https://postimg.cc/ykBN7Pf6)

**c. Angular application setup & run:**

 - Open Visual Studio Code.
 - Click "Open File" form File menu (see screenshot below).
 [![vs-code-open-folder.jpg](https://i.postimg.cc/4NYV2xkm/vs-code-open-folder.jpg)](https://postimg.cc/bsjZs8vh)
 - Select "chat-client" folder (see screenshot below).
 [![vs-code-select-folder.jpg](https://i.postimg.cc/ryn59tHB/vs-code-select-folder.jpg)](https://postimg.cc/s1WBj1sm) 
 - Open VS Code terminal by pressing Ctrl+` keyboard shortcut.
 - Run the following command in VS Code terminal (see screenshot below) to install all required node modules: 

> npm i

 [![vs-code-terminal.jpg](https://i.postimg.cc/cCHwSsvk/vs-code-terminal.jpg)](https://postimg.cc/47DmvRbp)
 - After all node modules are installed, run the following comand in VS Code terminal to run the client application server and open in browser: 
 

> ng serve --open

**How to use the app:**

 - The first page an you will see is the login page, which also provides link to register option. If you are already registered, then you can get logged in by providing the registered email address and click "Login".
[![login.jpg](https://i.postimg.cc/j2FNqGNx/login.jpg)](https://postimg.cc/gL3rNtNQ)
- If you doesn't have an account, then you have to register first by clicking "Register" button from login page. In registration page, you have to provide first name, last name and email to register. After providing the information, you have to click "Register" button to complete the registration. You can also click "Cancel" button to cancel the registration. After registration has been completed, you will be redirected to login page.
[![register.jpg](https://i.postimg.cc/DwssFpzh/register.jpg)](https://postimg.cc/qNJgxLnD)
- After successful login, you will be redirected to home page, where you can see other online users and start chatting with them by clicking on their name. If you have chatted previously with the selected user, you will also see previous chat messages along with the timestamp.
[![chatting-view.png](https://i.postimg.cc/VNWC0SMH/chatting-view.png)](https://postimg.cc/4KndrxWz)
- You will also be able to delete specific message with another user. There are two deletion option: "Delete for me", "Delete for everyone". You can see these options by clicking on the dot menu icon on any message (see screenshot below). "Delete for me" option will delete the message only for you, but the other person will be able to see the message. "Delete for everyone" option will delete the message for both you and the other user.
[![delete-options.jpg](https://i.postimg.cc/d0YC0R7y/delete-options.jpg)](https://postimg.cc/QFfC4TJ8)
- You can logout from the application by clicking "Logout" button on the top-right corner of the page. This will get you back to the login screen.
[![logout.jpg](https://i.postimg.cc/HxQMRHWv/logout.jpg)](https://postimg.cc/YGCjL5WQ)