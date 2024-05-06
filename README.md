This project is built on C# with Selenium, SpecFlow, and NUnit to test the TradeMe sandbox website. I have utilized WireMock for testing API interactions, and Selenium for UI testing.
**UI Testing**
This section involves testing the 3 different features which include Login, Search and ListItem.

**Login Scenarios:**
When dealing with scenarios involving reCaptcha, automating interactions with reCaptcha is not straightforward due to its purpose of preventing automated access. 
However, I have still automated other aspects of the customer login process and handled reCaptcha manually.

SC01: Validates TradeMe login page, enters valid credentials, and attempts to log in.
      The IsLoggedIn() method verifies if the user is logged in by checking the presence of a specific element on the page after login (checking for logout button  presence).
      Since reCaptcha cannot be directly automated due to its security measures, manual intervention is required during testing to solve the reCaptcha challenge.
      Alternatively, I have explored implementing services like 2Captcha to solve the Image captcha but have not implemented them in code. 
      Other scenarios also included thoroughly verifying the login page and login functionality.




