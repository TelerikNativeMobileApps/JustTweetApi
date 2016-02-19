#JustTweet nativeScript application

This is a simple tweet app. It uses a web.Api backend with the following endpoints: 

- POST - /api/account/register ({ email: "xxx", password: "xxx", confirmPassword: "xxx"})
- POST - /Token (username, password) - returns key
- POST - api/Tweets ({ Text: "xxx"})
- GET - api/Tweets - returns tweets

## Idea

The idea of the app is to be twitter-like. Users will have to register/login to use it. After this is done
the user will see latest tweets (with text, date, creator name). Scrolling down will make more tweets appear. Users can also make new tweets, which can be seen by other users.
