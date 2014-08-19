NGL
===
Next Generation Learning Platform

##Our Vision
GATHER INSTRUCTION AND OPERATIONAL STUDENT DATA AND SHARE IT FOR ONE SCHOOL

##Our Value Proposition
For Next Generation schools 
Who want to provide timely and relevant data reports, 
The NGL Platform is an integrated data store 
That unifies data to give a single shareable view. 
Unlike the monopolistic organizations like Power School and Jupiter, 
Our project follows the Design Principles.

##Developer Setup
To run the website, 
 - Change your system variables to have a 'BlobConnectionString' system variable set to: 'DefaultEndpointsProtocol=https;AccountName=\<YOUR ACCOUNT NAME\>;AccountKey=\<YOUR AZURE ACCOUNT KEY\>'
 - Clone the repository, run the `resetdb.bat` command found on the root of the repository
 - Open the solution and run the NGL.Web project. On initiation the website looks for the database migration scripts and runs the delta. Since this is your first time running the website, it might take a while as it's building the database schema and inserting the required reference data.

##Definition of Done
If you want to contribute to the codebase, please fork the repository and submit a GitHub Pull Request. Your code should comply with our Definition of Done before it's accepted:

 - Code has been peer reviewed
 - No ReSharper warnings
 - Unit test coverage for business logic and repositories
 - Unit test coverage for complex controllers
 - Automated UI tests for every feature 
 - Integration tests added if needed
 - Code must be completely checked in to the source control 
 - The build and all the automated tests should be green
 - UI looks nice and works on different resolutions on major browsers 
 - End user validation and tooltips are done
 - Security permission checks have been implemented
 - Automated database migration scripts are provided
 - Sample data needed to test the feature is scripted, if required

##Deploying to Azure
The codebase has the required azure settings. To deploy to Azure, create an Azure account, right click on the website project from the solution explorer, click publish, logon to your Azure account when asked, go through the wizard to create the website and the database on your Azure account, and in the end click publish. At the end of the publish wizard you can run the deployed website. Again, the first run is going to take a while as the website is populating the Sql Azure.
