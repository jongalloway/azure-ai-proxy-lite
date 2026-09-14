# Base image for the devcontainer. Package-manager registries are pinned to the
# Microsoft package feed proxy here (rather than only in devcontainer.json's
# remoteEnv/postCreateCommand) because devcontainer Features install their own
# packages (e.g. the Python feature's pip tools) during the image build itself,
# before remoteEnv or postCreateCommand ever run.
FROM mcr.microsoft.com/devcontainers/base:bookworm

ARG PIP_INDEX_URL=https://packagefeedproxy.microsoft.io/pypi/simple/
ARG NPM_CONFIG_REGISTRY=https://packagefeedproxy.microsoft.io/npm/

ENV PIP_INDEX_URL=${PIP_INDEX_URL} \
    NPM_CONFIG_REGISTRY=${NPM_CONFIG_REGISTRY}
