FROM microsoft/dotnet:2.2-sdk AS build
COPY . /otakushelter/mangas/parser
WORKDIR /otakushelter/mangas/parser/src/OtakuShelter.Mangas.Parser
RUN dotnet publish -c Release -o artifacts

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /otakushelter/mangas/parser
COPY --from=build /otakushelter/mangas/parser/src/OtakuShelter.Mangas.Parser/artifacts ./
ENTRYPOINT ["dotnet", "OtakuShelter.Mangas.Parser.dll"] 