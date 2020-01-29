# NBP-Parser
NBP Parser is a console and WPF application, that allows you check data for selling and buying rates from NBP - National Bank of Poland. It fetches valid XML files that matches with given date's, then search for given currency. Static class "Statistics" allows to give us accurate values: minimum rate, maximum rate, average and standard deviation.
### How to use
You have to run .exe file through CMD, example below:
```
KursyWalut.exe EUR 02.01.2020 21.01.2020
```
![CMD example](https://i.gyazo.com/ab85881d516ecc1775731a440c809356.png "CMD example")

Or you can can run .exe file without parameters, then WPF application will appear:
```
KursyWalut.exe
```
![WPF application](https://i.gyazo.com/d623eb6366b222db74986434ac1f3d36.png "WPF app")
