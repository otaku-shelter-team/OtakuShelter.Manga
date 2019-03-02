FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/mangas/service
WORKDIR /otakushelter/mangas/service/src/OtakuShelter.Mangas.Web
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/mangas/service
COPY --from=build /otakushelter/mangas/service/src/OtakuShelter.Mangas.Web/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Mangas.Web.dll"] 