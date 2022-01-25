# Hospital management system

A console application that works with the Microsoft SQL Server database using Entity Framework Core 6 with code first approach.
The application allows you to set up accounts and manage patients in the hospital.


## Design patterns

#### Creational patterns
<ul>
    <li>
      Builder
      <ul>
        <li>Hospital.UI/Builder</li>
      </ul>
    </li>
    <li>
      Singleton
      <ul >
        <li>Hospital.DataLayer/ConnectionStringSingleton.cs</li>
      </ul>
    </li>
  </ul>
  
  #### Structural patterns
<ul>
    <li>
      Facade
      <ul >
        <li>Hospital.UI/Facade</li>
      </ul>
    </li>
    <li>
      Decorator
      <ul>
        <li>Hospital.UI/Decorator</li>
      </ul>
    </li>
  </ul>
  
   #### Behavioral patterns
<ul>
    <li>
      Strategy
      <ul >
        <li>Hospital.UI/Strategy</li>
      </ul>
    </li>
    <li>
      Memento
      <ul>
        <li>Hospital.UI/Memento</li>
      </ul>
    </li>
  </ul>


## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* npm
  ```sh
  npm install npm@latest -g
  ```

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1. Get a free API Key at [https://example.com](https://example.com)
2. Clone the repo
   ```sh
   git clone https://github.com/your_username_/Project-Name.git
   ```
3. Install NPM packages
   ```sh
   npm install
   ```
4. Enter your API in `config.js`
   ```js
   const API_KEY = 'ENTER YOUR API';
   ```

<p align="right">(<a href="#top">back to top</a>)</p>


## Copyright and License

Start Bootstrap website licensed [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/). Free themes and templates on Start Bootstrap released under MIT license.
