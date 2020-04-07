## How to tell GitHub to not track updates in certain files.

-Adding a .gitignore file to your repository will tell GitHub to ignore updates to any of the files that are listed in the .gitignore file.

In the case of this project, the Connection string that contains username and password information should not be stored publically in GitHub.
Adding these lines to the .gitignore file will stop updates from being pushed to the appsettings.json file:
#ignore appsettings configuration files
**/appsettings.json
**/appsettings.development.json
**/appsettings.staging.json
**/appsettings.production.json

When testing, updates still seemed to be posting. Typing the following command in the command line within the directory of a cloned reository on my computer seemed to do the trick.

git rm --cached **/appsettings.json
