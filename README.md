# TradeMe UI & API Automation #
>This project is built on C# with Selenium, SpecFlow, and NUnit to test the TradeMe sandbox website. 
>I have utilized WireMock for testing API interactions, and Selenium for UI testing.
## UI Testing ##
This section involves testing the 3 different features which include Login, Search and ListItem.

### Login Scenarios: ###
When dealing with scenarios involving reCaptcha, automating interactions with reCaptcha is not straightforward due to its purpose of preventing automated access. 
However, I have still automated other aspects of the customer login process and handled reCaptcha manually.

SC01: 
1. Validates TradeMe login page, enters valid credentials and attempts to log in.
2. The IsLoggedIn() method verifies if the user is logged in by checking the presence of a specific element on the page after login (checking for logout button  presence).
3. Since reCaptcha cannot be directly automated due to its security measures, manual intervention is required during testing to solve the reCaptcha challenge.
4. Alternatively, I have explored implementing services like 2Captcha to solve the Image captcha but have not implemented them in code.
5. Other scenarios also included thoroughly verifying the login page and login functionality.

## API Testing ##

I have opted to use WireMocks in my solutions to work with API calls for testing the Listing method and selling methods.
1. Setup WireMock: First, I set up WireMock, which is a flexible library for stubbing and mocking HTTP services. I used the standalone WireMock server and  integrated it directly into my test code.
2. Defined Expectations: Using WireMock, I defined the expectations for the HTTP requests that the RestSharp client will make. This included specifying the request URL, HTTP method, headers, query parameters, and the response I wanted WireMock to return. I have specified JSON files with data for both selling and listing methods.
3. Write Test Cases: I have written test cases using RestSharp to make requests to GET/POST API's. Useed WireMock to mock the server's responses based on the defined expectations.

   For more details, refer reference document attached.







