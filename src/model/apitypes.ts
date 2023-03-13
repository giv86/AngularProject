// ..\Models\JwsSettings.cs
export interface JwsSettings {
}

// ..\Models\Dbos\DboActions.cs
export interface DBOActions extends DboBaseModel<IdTypeOFActions> {
  Name: string;
  FirstDescription: string;
  SecondDescription: string;
  ModelName: ModelName;
  AvailableAction: AvailableActions;
  TargetId: number;
}

// ..\Models\Dbos\DboBaseModel.cs
export interface DboBaseModel<T> {
  Id: T;
  CreatedAt: string;
  UpdatedAt: string;
}

// ..\Models\Dbos\DboConversations.cs
export interface DBOConversations extends DboBaseModel<IdTypeOFConversation> {
  Name: string;
  Description: string;
  CanBeReused: boolean;
  HasBeenUsed: boolean;
}

// ..\Models\Dbos\DboDialogues.cs
export interface DBODialogues extends DboBaseModel<IdTypeOFDialogue> {
  Text: string;
  CanBeReused: boolean;
  HasBeenUsed: boolean;
}

// ..\Models\Dbos\DboEnums.cs
export enum IdTypeOFUser {
}

// ..\Models\Dbos\DboEnums.cs
export enum IdTypeOFLocation {
}

// ..\Models\Dbos\DboEnums.cs
export enum IdTypeOFConversation {
}

// ..\Models\Dbos\DboEnums.cs
export enum IdTypeOFDialogue {
}

// ..\Models\Dbos\DboEnums.cs
export enum IdTypeOFActions {
}

// ..\Models\Dbos\DboEnums.cs
export enum IdTypeOFHero {
}

// ..\Models\Dbos\DboEnums.cs
export enum AvailableActions {
  WalkTo = 'WalkTo',
  LookAt = 'LookAt',
  Open = 'Open',
  Move = 'Move',
  Consume = 'Consume',
  PickUp = 'PickUp',
  Close = 'Close',
  Use = 'Use',
  TalkTo = 'TalkTo',
  Remove = 'Remove',
  Wear = 'Wear',
  Give = 'Give',
  Fight = 'Fight',
  Dodge = 'Dodge',
  Run = 'Run',
}

// ..\Models\Dbos\DboEnums.cs
export enum ModelName {
  User = 'User',
  Location = 'Location',
  Conversation = 'Conversation',
  Dialogue = 'Dialogue',
  Actions = 'Actions',
  Hero = 'Hero',
}

// ..\Models\Dbos\DboEnums.cs
export enum UserRole {
  Admin = 'Admin',
  User = 'User',
}

// ..\Models\Dbos\DboHeroes.cs
export interface DBOHeroes extends DboBaseModel<IdTypeOFHero> {
  Name: string;
  LocationId: IdTypeOFLocation;
  IsActive: boolean;
  Location: DBOLocations;
}

// ..\Models\Dbos\DboLocations.cs
export interface DBOLocations extends DboBaseModel<IdTypeOFLocation> {
  Name: string;
  Description: string;
  CanBeReused: boolean;
  HasBeenUsed: boolean;
}

// ..\Models\Dbos\DboUsers.cs
export interface DBOUsers extends DboBaseModel<IdTypeOFUser> {
  Email: string;
  Password: string;
  IsAdmin: boolean;
  IsActive: boolean;
  PasswordHash: Uint8Array;
  PasswordSalt: Uint8Array    ;
  UserRole: UserRole;
}

// ..\Models\Dictionaries\DictionaryActionsToConversation.cs
export interface DictionaryActionsToConversation extends DictionaryBase {
}

// ..\Models\Dictionaries\DictionaryActionsToDialogues.cs
export interface DictionaryActionsToDialogues extends DictionaryBase {
}

// ..\Models\Dictionaries\DictionaryActionsToLocation.cs
export interface DictionaryActionsToLocation extends DictionaryBase {
}

// ..\Models\Dictionaries\DictionaryBase.cs
export interface DictionaryBase {
  DictionaryId: number;
  From: number;
  To: number;
}

// ..\Models\Dictionaries\DictionaryConversationsToLocation.cs
export interface DictionaryConversationsToLocation extends DictionaryBase {
}

// ..\Models\Dictionaries\DictionaryDialoguesToConversation.cs
export interface DictionaryDialoguesToConversation extends DictionaryBase {
}

// ..\Models\Dictionaries\DictionaryHeroesToUser.cs
export interface DictionaryHeroesToUser extends DictionaryBase {
}

// ..\Models\Dtos\Requests\AuthenticateUserRequest.cs
export interface AuthenticateUserRequest {
  Email: string;
  Password: string;
}

// ..\Models\Dtos\Requests\RegisterNewUserRequest.cs
export interface RegisterNewUserRequest {
  Email: string;
  Password: string;
  IsAdmin: boolean;
}

// ..\Models\Dtos\Responds\AuthenticateUserResponse.cs
export interface AuthenticateUserResponse {
  UserId: IdTypeOFUser;
  Email: string;
  IsAdmin: boolean;
  IsAuthenticated: boolean;
}
