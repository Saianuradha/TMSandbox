using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net;

public class CaptchaSolver
{
    private string apiKey;
    private WebClient webClient;

    public CaptchaSolver(string apiKey)
    {
        this.apiKey = apiKey;
        this.webClient = new WebClient();
    }

    public string SolveCaptcha(string captchaImageUrl)
    {
        // Download captcha image
        byte[] imageBytes = webClient.DownloadData(captchaImageUrl);
        string base64String = Convert.ToBase64String(imageBytes);
        string encodedImage = WebUtility.UrlEncode(base64String);

        // Send captcha to 2Captcha API
        string apiUrl = "http://2captcha.com/in.php";
        string postData = $"method=base64&key={apiKey}&body={encodedImage}";
        string response = webClient.UploadString(apiUrl, postData);

        // Parse captcha ID from response
        string captchaId = response.Split('|')[1];

        // Wait for captcha to be solved (polling)
        string solution = "";
        while (solution == "")
        {
            System.Threading.Thread.Sleep(5000); // Wait 5 seconds before checking again
            string getResultUrl = $"http://2captcha.com/res.php?key={apiKey}&action=get&id={captchaId}";
            string resultResponse = webClient.DownloadString(getResultUrl);
            if (resultResponse.Contains("OK"))
            {
                solution = resultResponse.Split('|')[1];
            }
        }

        return solution;
    }
}

public class LoginTest
{
    public void TestLogin(string username, string password, string captchaImageUrl)
    {
        string apiKey = "your_2captcha_api_key";

        // Initialize WebDriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to the login page
        driver.Navigate().GoToUrl("https://example.com/login");

        // Find and fill in the login form
        driver.FindElement(By.Id("username")).SendKeys(username);
        driver.FindElement(By.Id("password")).SendKeys(password);

        // Solve captcha
        CaptchaSolver captchaSolver = new CaptchaSolver(apiKey);
        string captchaSolution = captchaSolver.SolveCaptcha(captchaImageUrl);

        // Fill in captcha solution
        driver.FindElement(By.Id("captchaInput")).SendKeys(captchaSolution);

        // Submit the login form
        driver.FindElement(By.Id("loginButton")).Click();

        // Check if login was successful (you can add more validation here)
        bool isLoggedIn = driver.Url.Equals("https://example.com/dashboard");

        // Close the browser
        driver.Quit();

        // Output result
        if (isLoggedIn)
        {
            Console.WriteLine("Login successful!");
        }
        else
        {
            Console.WriteLine("Login failed!");
        }
    }
}


