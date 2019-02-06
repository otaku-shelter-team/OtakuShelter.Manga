FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/manga/service
WORKDIR /otakushelter/manga/service/src/OtakuShelter.Manga.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/manga/service
COPY --from=build /otakushelter/manga/service/src/OtakuShelter.Manga.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Manga.Web.dll"] 