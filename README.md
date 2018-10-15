# BannerFlow

This project use asp.net web api.
The methods that conforms to CRUD is found in BannerController.cs plus an additional method that renders the html for the banner.
The banners themselves are backed in MongoDB.
The tests are done with Postman.

The crud methods:
Create - POST /api/banner ContentType: json/application
Read - GET /api/banner/{id}
Update - PUT /api/banner ContentType: json/application
Delete - DELETE /api/banner/{id}
