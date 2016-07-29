## _Hair Salon with C#, Nancy, and Razor_

## _Project Specifications_

#### By _**Shokouh Farvid**_

## Description/Specs

Create an app for a hair salon. The owner is able to add to a list of the stylists, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist.


** Clone this repository, and on your computer, run "DNU restore" at the PowerShell prompt in the top directory of the cloned repository. Then type in "DNX Kestrel" at the same prompt and a local instance of the kestrel server will boot. Navigate in your browser to "LocalHost:5004" to view the homepage.

** Creat database and tables:
* CREATE DATABASE hair_salon;
* GO
* USE hair_salon;
* GO
* CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));
* CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255));
* GO

## Known Bugs

## Support and contact details
Please contact the authors if you have any questions or comments.

## Technologies Used
This webpage was written using C#, Nancy, Razor, CSS, and Bootstrap.

### License
Copyright (c) 2016 _**Shokouh Farvid **_

This software is licensed under the MIT license.
