
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <h3 align="center">Claytondus.EasyPost</h3>

  <p align="center">
    An unofficial .NET wrapper for the <a href="https://www.EasyPost.com">EasyPost</a> API.
    <br />
    <a href="https://github.com/claytondus/Claytondus.EasyPost/issues">Report Bug</a>
    ·
    <a href="https://github.com/claytondus/Claytondus.EasyPost/issues">Request Feature</a>
  </p>
</p>



<!-- ABOUT THE PROJECT -->
## About The Project

EasyPost is a multi-carrier shipping services API.  We use it at [Agonswim.com](https://www.agonswim.com) to generate shipping labels and track packages.  This project is a typed async API wrapper for .NET Standard. 

### Built With

* [JetBrains Rider](https://jetbrains.com/rider)
* [Flurl](https://flurl.dev)


## Usage

1. Get an account and API key at [https://easypost.com](https://https://app.EasyPost.com/app/login/register)
2. Add the NuGet package to your project
   ```sh
   dotnet add package Claytondus.EasyPost
   ```
3. Instantiate the client
   ```C#
   var apiKey = "....";
   var client = new EasyPostClient(apiKey);
   ```
   You may also pass in an ILogger to log requests and responses:
   ```C#
   var client = new EasyPostClient(apiKey, logger:logger);
   ```
4. Call the API
   ```C#
   var response = await client.await client.CreateTrackerAsync(new Tracker
   {
       tracking_code = "EZ1000000001",
       carrier = "UPS"
   });
   ```

### API Support
* Addresses
* Parcels
* Shipments
   * Options
   * Rates
   * Insurance
   * Refunds
   * SmartRate
* Trackers
* CustomsInfos, CustomsItems
* Events
* Fees
* Orders
* Webhooks

Additional APIs are supported upon request.



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

I AM NOT AFFILIATED WITH EasyPost.  For questions about their service please contact support@EasyPost.com or @EasyPost on twitter.

Clayton Davis - cd@ae4ax.net

Project Link: [https://github.com/claytondus/Claytondus.EasyPost](https://github.com/claytondus/Claytondus.EasyPost)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements
* [EasyPost](https://EasyPost.com)



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/claytondus/Claytondus.EasyPost.svg?style=for-the-badge
[contributors-url]: https://github.com/claytondus/Claytondus.EasyPost/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/claytondus/Claytondus.EasyPost.svg?style=for-the-badge
[forks-url]: https://github.com/claytondus/Claytondus.EasyPost/network/members
[stars-shield]: https://img.shields.io/github/stars/claytondus/Claytondus.EasyPost.svg?style=for-the-badge
[stars-url]: https://github.com/claytondus/Claytondus.EasyPost/stargazers
[issues-shield]: https://img.shields.io/github/issues/claytondus/Claytondus.EasyPost.svg?style=for-the-badge
[issues-url]: https://github.com/claytondus/Claytondus.EasyPost/issues
[license-shield]: https://img.shields.io/github/license/claytondus/Claytondus.EasyPost.svg?style=for-the-badge
[license-url]: https://github.com/claytondus/Claytondus.EasyPost/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/claytond
