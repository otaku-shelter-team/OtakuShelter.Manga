FROM microsoft/dotnet:2.2-sdk AS build
COPY . /manga/service
WORKDIR /manga/service/src/OtakuShelter.Manga.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /manga/service
COPY --from=build /manga/service/src/OtakuShelter.Manga.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Manga.Web.dll"]