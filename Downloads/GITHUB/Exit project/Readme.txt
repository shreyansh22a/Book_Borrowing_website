1. Update the database name in the connection string preent in appsetting.json file.
2. Need to run Update-Database command in NugetPackageManagerConsolel to create the database.
3. To create the admin user you need ti go in swagger an execute the seedadmin api which will automatically creates a admin user with following credentials
	Email: Admin@gmail.com
	Password: Admin@1234
4.Change the UploadsFolderlocation in backend DataAccessLayer/Repository/ImageCopyRepository to your assets/images location of your frontend.