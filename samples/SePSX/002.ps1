ipmo C:\Projects\PS\STUPS\SePSX\bin\Release35\SePSX.dll;
#Start-SeFirefox | Enter-SeURL "http://hotels24.ua/hotels/%D0%B3%D0%BE%D1%81%D1%82%D0%B8%D0%BD%D0%B8%D1%86%D1%8B-%D0%BE%D0%B1%D0%BB%D0%B0%D1%81%D1%82%D1%8C/%D0%9A%D0%B8%D0%B5%D0%B2%D1%81%D0%BA%D0%B0%D1%8F/";
Start-SeChrome | Enter-SeURL "http://hotels24.ua/hotels/%D0%B3%D0%BE%D1%81%D1%82%D0%B8%D0%BD%D0%B8%D1%86%D1%8B-%D0%BE%D0%B1%D0%BB%D0%B0%D1%81%D1%82%D1%8C/%D0%9A%D0%B8%D0%B5%D0%B2%D1%81%D0%BA%D0%B0%D1%8F/";
Get-SeWebElement -XPath "//div[@class='layout-header-bottom']//span[text()='Гостиницы']" | Move-SeCursorToWebElement -Verbose;
Get-SeWebElement -LinkText "Винницкая" | Invoke-SeWebElementClick -Verbose;