# Ascii Graphite Consumer

## About this project

We use Raspberry Pis as our stats monitors, and they have trouble running multiple tabs in Chrome.

I was talking to a colleague, and the idea came up to use a simple text browser rather than a full graphical browser like Chrome.

So I thought I would have a play with creating a Graphite consumer that just outputs Ascii art.

This is that project.

## Getting started

The name of the stats server is saved in a secret config file, which is hidden from git. You will need to add this:

In **GraphiteConsumer.Web**, create a folder named **App_Settings**, and a file within it named **AppSettings.config**.

In this file, add the following XML:

	<?xml version="1.0"?>
	<appSettings>
		<add key="GraphiteServerName" value="**your server name**"/>
	</appSettings>