#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
COPY *.csproj .
RUN dotnet restore
#bu katmani ekleme sebebi daha onceden olusturulan dosyalari cache den okuyacaktir.(controller veya class) .cs olusturursam veya degistirirsem burasi tekrardan butun dosyalari olusturmak yerine degisikleri gorur ve sadece degisiklik olan yerde publish dosyasi olusturur.
  
  #ornegin style uzantili dosyalarimda olusturdugum veya degistirdigim bir durumda csproj icerisinden farkli olanlari olacak ve bana o puslish dosyasini verecek

  #bu duruma multistage denir.

COPY . .
RUN dotnet publish DockerizeAsPNetCoreMVC.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS ="http://*:4500"
ENTRYPOINT ["dotnet", "DockerizeAsPNetCoreMVC.dll"]

#docker run -p 5000:80 --name container(containername) 54d(imagenameId) ile console dan farkli olarak port numarasi atamam lazim.. 5000 isletim sisteminin portu, 80 portu ise uygulamanin ayaga kalkacagi porttur.
#image lerin boyutlarini kucultmek icin yapacagim sey multistage yontemidir.

#sdk 
  #app
    #out
     #publish data
