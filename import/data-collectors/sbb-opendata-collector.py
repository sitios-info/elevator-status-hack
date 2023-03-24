import codecs
import json
from codecs import decode

import requests
importDataDict = {}
idMappingDict = {}
SOURCE_TYPE ="SBB_OPEN_DATA"
OPERATOR = {
    "name": "SBB",
    "contactPhone": "+41 800 007 102"
}

headers = {
    "Content-Type": "application/json"
}

elevatorsUrl = "https://data.sbb.ch/api/records/1.0/search/?dataset=aufzugsstammdaten&q=&facet=type&facet=didok&refine.type=T11"

eventsUrl = "https://data.sbb.ch/api/records/1.0/search/?dataset=aufzugzustand&rows=100&facet=ts&facet=direction&facet=operational&facet=didok&facet=type&refine.type=T11&refine.operational=false"
respText = requests.get(eventsUrl).text
jsonDict = json.loads(respText)

records = jsonDict['records']

evlevatorsRespRecords =json.loads(requests.get(elevatorsUrl).content)['records']
for elevatorElement in evlevatorsRespRecords:
    elevatorCreationDto = {}
    geoObj = {}
    elevator = elevatorElement['fields']
    elevatorCreationDto['properties'] = {}
    elevatorCreationDto['properties']['description'] = elevator['description']
    elevatorCreationDto['properties']['station'] = elevator['bezeichnung_offiziell']

    geoObj['geometry'] = {}
    geoObj['geometry']['coordinates'] = elevator['geopos']
    geoObj['addressText'] = elevator['location']
    elevatorCreationDto['location'] = geoObj

    elevatorCreationDto['operator'] = OPERATOR
    importDataDict[elevator['aks_id']] = elevatorCreationDto
    response = requests.post("http://localhost:5028/api/Elevators", json.dumps(elevatorCreationDto), headers=headers,verify=False)
    print(response.status_code)
    print(response.text)
    createdElevator = json.loads(response.text)
    idMappingDict[elevator['aks_id']] = createdElevator['id']

    

print(idMappingDict)




for record in records:
    eventToPush = {}
    actualRecord= record['fields']
    eventToPush['timeStamp'] = actualRecord['ts']
    eventToPush['metadataSourceInfo'] = {}
    eventToPush['reason'] = ""
    if(not actualRecord['operational']):
        eventToPush['operationStatus'] = "NotOperational"
    else :
        eventToPush['operationStatus'] = "Operational"

    if(idMappingDict.keys().__contains__(actualRecord['aks_id'])):
        print("id exists")
        response = requests.post("http://localhost:5028/api/OperationChange",params={'elevatorId':idMappingDict[actualRecord['aks_id']]}, data=json.dumps(eventToPush), headers=headers,verify=False)
        print(f"{response.status_code} event {response.text}")

    else:
        print("missing id")
    print(eventToPush)
    
