// ..\Models\ActionsToConversation.cs
export interface ActionsToConversation extends BaseDictionary {
}

// ..\Models\ActionsToDialogues.cs
export interface ActionsToDialogues extends BaseDictionary {
}

// ..\Models\ActionsToLocation.cs
export interface ActionsToLocation extends BaseDictionary {
}

// ..\Models\BaseDictionary.cs
export interface BaseDictionary {
    DictionaryId: number;
    From: number;
    To: number;
}

// ..\Models\ConversationsToLocation.cs
export interface ConversationsToLocation extends BaseDictionary {
}

// ..\Models\DBOActions.cs
export interface DBOActions extends DBOBaseModel<IdTypeOFActions> {
    Name: string;
    FirstDescription: string;
    SecondDescription: string;
    ModelName: ModelName;
    AvailableAction: AvailableActions;
    TargetId: number;
}

// ..\Models\DBOBaseModel.cs
export interface DBOBaseModel<T> {
    Id: T;
    CreatedAt: string;
    UpdatedAt: string;
}

// ..\Models\DBOConversations.cs
export interface DBOConversations extends DBOBaseModel<IdTypeOFConversation> {
    Name: string;
    Description: string;
    CanBeReused: boolean;
    HasBeenUsed: boolean;
}

// ..\Models\DBODialogues.cs
export interface DBODialogues extends DBOBaseModel<IdTypeOFDialogue> {
    Text: string;
    CanBeReused: boolean;
    HasBeenUsed: boolean;
}

// ..\Models\DBOEnums.cs
export enum IdTypeOFUser {
}

// ..\Models\DBOEnums.cs
export enum IdTypeOFLocation {
}

// ..\Models\DBOEnums.cs
export enum IdTypeOFConversation {
}

// ..\Models\DBOEnums.cs
export enum IdTypeOFDialogue {
}

// ..\Models\DBOEnums.cs
export enum IdTypeOFActions {
}

// ..\Models\DBOEnums.cs
export enum IdTypeOFHero {
}

// ..\Models\DBOEnums.cs
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

// ..\Models\DBOEnums.cs
export enum ModelName {
    User = 'User',
    Location = 'Location',
    Conversation = 'Conversation',
    Dialogue = 'Dialogue',
    Actions = 'Actions',
    Hero = 'Hero',
}

// ..\Models\DBOHeroes.cs
export interface DBOHeroes extends DBOBaseModel<IdTypeOFHero> {
    Name: string;
    LocationId: IdTypeOFLocation;
    IsActive: boolean;
    Location: DBOLocations;
}

// ..\Models\DBOLocations.cs
export interface DBOLocations extends DBOBaseModel<IdTypeOFLocation> {
    Name: string;
    Description: string;
    CanBeReused: boolean;
    HasBeenUsed: boolean;
}

// ..\Models\DBOUsers.cs
export interface DBOUsers extends DBOBaseModel<IdTypeOFUser> {
    Email: string;
    Password: string;
    IsAdmin: boolean;
    IsActive: boolean;
    ConfirmPassword: string;
}

// ..\Models\DialoguesToConversation.cs
export interface DialoguesToConversation extends BaseDictionary {
}

// ..\Models\DTOAction.cs
export interface DTOAction extends DTOBaseModel<IdTypeOFActions> {
    Name: string;
    FirstDescription: string;
    SecondDescription: string;
    ModelName: ModelName;
    AvailableAction: AvailableActions;
    TargetId: number;
}

// ..\Models\DTOBaseModel.cs
export interface DTOBaseModel<T> {
    Id: T;
    CreatedDate: string;
    ModifiedDate: string;
}

// ..\Models\DTOConversation.cs
export interface DTOConversation extends DTOBaseModel<IdTypeOFConversation> {
    Name: string;
    Description: string;
    CanBeReused: boolean;
    HasBeenUsed: boolean;
    Dialogues: DTODialogue[];
    Actions?: DTOAction[];
}

// ..\Models\DTODialogue.cs
export interface DTODialogue extends DTOBaseModel<IdTypeOFDialogue> {
    Text: string;
    CanBeReused: boolean;
    HasBeenUsed: boolean;
    Actions?: DTOAction[];
}

// ..\Models\DTOHero.cs
export interface DTOHero extends DTOBaseModel<IdTypeOFHero> {
    Name: string;
    LocationId: IdTypeOFLocation;
    IsActive: boolean;
    Location?: DBOLocations;
}

// ..\Models\DTOInteraction.cs
export interface DTOInteraction {
    FirstHeaderLine: string;
    SecondHeaderLine: string;
    ThirdHeaderLine: string;
    ConsoleBody: string;
    FirstInteractionLine: string;
    SecondInteractionLine: string;
    ThirdInteractionLine: string;
    FourthInteractionLine: string;
    UserInput: string;
}

// ..\Models\DTOLocation.cs
export interface DTOLocation extends DTOBaseModel<IdTypeOFLocation> {
    Name: string;
    Description: string;
    CanBeReused: boolean;
    HasBeenUsed: boolean;
    Conversations?: DBOConversations[];
    Actions?: DTOAction[];
}

// ..\Models\DTOUser.cs
export interface DTOUser {
    Email: string;
    Password: string;
    UserType: UserType;
    Heroes: DTOHero[];
    Locations: DTOLocation[];
    IsAuthorized: boolean;
}

// ..\Models\DTOUser.cs
export enum UserType {
    User = 'User',
    Admin = 'Admin',
}

// ..\Models\HeroesToUser.cs
export interface HeroesToUser extends BaseDictionary {
}
