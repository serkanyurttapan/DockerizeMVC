#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
COPY *.csproj .
RUN dotnet restore
#bu katmaný ekleme sebebi daha önceden oluþturulan dosyalarý cache den okuyacaktýr.(controller veya class) .cs oluþturursam veya deðiþtirirsem burasý tekrardan bütün dosyalarý oluþturmak yerine deðiþikleri görür ve sadece deðiþiklik olan yerde publish dosyasý oluþturur.
  
  #örneðin style uzantýlý dosyalarýmda oluþturduðum veya deðiþtirdiðim bir durumda csproj içerisinden farklý olanlarý olacak ve bana o puslish dosyasýný verecek

  #bu duruma multistage denir.

COPY . .
RUN dotnet publish DockerizeAsPNetCoreMVC.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS ="http://*:4500"
ENTRYPOINT ["dotnet", "DockerizeAsPNetCoreMVC.dll"]

#docker run -p 5000:80 --name container(containername) 54d(imagenameId) ile console dan farklý olarak port numarasý atamam lazým.. 5000 iþletim sisteminin portu, 80 portu ise uygulamanýn ayaða kalkacaðý porttur.
#image lerin boyutlarýný küçültmek için yapacaðým þey multistage yöntemidir.

#sdk 
  #app
    #out
     #publish data
