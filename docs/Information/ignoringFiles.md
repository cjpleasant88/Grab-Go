## How to tell GitHub to not track updates in certain files.

-Adding a .gitignore file to your repository will tell GitHub to ignore updates to any of the files that are listed in the .gitignore file.

In the case of this project, the Connection string that contains username and password information should not be stored publically in GitHub.
Adding these lines to the .gitignore file will stop updates from being pushed to the appsettings.json file:
#ignore appsettings configuration files

**/appsettings.json

**/appsettings.development.json

**/appsettings.staging.json

**/appsettings.production.json

When testing, Below are command line commands for the various ways to stop updates (make sure you are in the directory of the file).

THIS REMOVES THE FILE FROM SHOWING UP IN GITHUB IF IT WAS ALREADY COMMITTED
git rm --cached appsettings.json

THIS KEEPS THE FILE IN GITHUB BUT STOPS TRACKING FUTURE CHANGES
git update-index --assume-unchanged <file>
  
 THIS TURNS BACK ON TRACKING
 git update-index --no-assume-unchanged <file>
