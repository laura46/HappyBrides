# HappyBrides
A website for couples to create a wish list for their wedding day. Guests can use the unique code to view the list and claim presents they want to buy.
-------------------

## Getting started
The following describes how to get happy brides up and running.

### Database
First get your DB ready, by executing the SQL files in the HappyBridesDB directory. First execute the `CreateHappyBridesDB` file and then execute the `HappyBridesStoredProcedures` file. 

### API
To connect to your database, adjust the `"DBConnection"` details in `appsettings.json` in the HappyBridesAPI directory.

### Sass
The front-end uses Sass for style, to make sure Sass is being compiled to css, please open a terminal in de HAPPYBRIDES directory and execute the following command: `sass --watch styles.scss styles.css`

Happy coding! :grin: :+1:
