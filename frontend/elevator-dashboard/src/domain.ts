export type GetElevatorsResult = Elevator[]

export interface Elevator {
  id: string
  openStreetMapId: string
  properties: {[key: string]:string}
  location: Location
  manufacturerName: string
  serialNumber: string
  operator: Operator
  isOperational: boolean
}

export interface Location {
  id: string
  geometry: Geometry
  openStreetMaPlaceId: string
  addressText: string
}

export interface Geometry {
  type: string
  coordinates: number[]
}

export interface Operator {
  id: string
  name: string
  contactEmail: string
  contactPhone: string
}