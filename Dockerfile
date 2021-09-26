FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ARG DEBIAN_FRONTEND=noninteractive
ARG source=./WordAnalyzer
WORKDIR /app
EXPOSE 80 443

#######################################################
# Add dependencies for Gdip in the runtime application. System.Drawing. 
#######################################################

RUN apt-get update
RUN apt-get upgrade -y
RUN apt-get install --assume-yes apt-utils
RUN apt-get install -y curl
RUN apt-get install -y sudo
RUN apt-get install -y curl software-properties-common

RUN ln -s /lib/x86_64-linux-gnu/libdl-2.24.so /lib/x86_64-linux-gnu/libdl.so

# install System.Drawing native dependencies
RUN apt-get install -y --allow-unauthenticated libc6-dev
RUN apt-get install -y --allow-unauthenticated libgdiplus
RUN apt-get install -y --allow-unauthenticated libx11-dev
RUN rm -rf /var/lib/apt/lists/*

COPY $source .
ENTRYPOINT ["dotnet", "WordAnalyzer.dll"]