var schedule = require('node-schedule');
var https = require('https');
var beehivesData = require("./beehivesData.js");
var _ = require('underscore-node');
var request = require('request');
var apiaryId = 1;
 
schedule.scheduleJob('*/10 * * * * *', function(){
    sendApinaryData();
});

var generateIntData = function(low, high){
	return Math.floor(Math.random() * (high - low + 1) + low);
}

var generateFloatData = function(low, high) {
	return Math.random() * (high - low) + low;
}

var getHiveData = function(guid, date) {
	var hiveData = {};
	hiveData.ApiaryId = apiaryId;
	hiveData.GUID = guid;
	hiveData.Timestamp = date;
	hiveData.Temperature = generateIntData(-10, 40);
	hiveData.Humidity = generateIntData(0, 100);
	hiveData.Weight = generateFloatData(20, 30);
	hiveData.Light = generateIntData(0, 255);
	return hiveData;
};

var sendApinaryData = function() {
	var apinaryGuids = beehivesData.getApiaryHivesData(apiaryId);
	var sensorsData = [];
	var currentDateTime = new Date();
	_.each(apinaryGuids, function(guid){
		var currentHiveData = getHiveData(guid, currentDateTime);
		sensorsData.push(currentHiveData);
	});

	request({
		url: "http://localhost:2276/api/sensorsInfo",
		method: "POST",
		json: sensorsData
	}, function(error, response, body){
		console.log(error);
	});
	
	console.log(sensorsData);
};




