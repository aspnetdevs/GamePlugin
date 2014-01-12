﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 5.0.61118.0
// 
namespace GamePlugin.Game {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Game.GameService")]
    public interface GameService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/GameService/GetStartMetadata", ReplyAction="http://tempuri.org/GameService/GetStartMetadataResponse")]
        System.IAsyncResult BeginGetStartMetadata(string gameId, string userId, System.AsyncCallback callback, object asyncState);
        
        string EndGetStartMetadata(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/GameService/SetMoveMetadata", ReplyAction="http://tempuri.org/GameService/SetMoveMetadataResponse")]
        System.IAsyncResult BeginSetMoveMetadata(string gameId, string userId, string metadata, int currentMoveNumber, System.AsyncCallback callback, object asyncState);
        
        void EndSetMoveMetadata(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GameServiceChannel : GamePlugin.Game.GameService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetStartMetadataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetStartMetadataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameServiceClient : System.ServiceModel.ClientBase<GamePlugin.Game.GameService>, GamePlugin.Game.GameService {
        
        private BeginOperationDelegate onBeginGetStartMetadataDelegate;
        
        private EndOperationDelegate onEndGetStartMetadataDelegate;
        
        private System.Threading.SendOrPostCallback onGetStartMetadataCompletedDelegate;
        
        private BeginOperationDelegate onBeginSetMoveMetadataDelegate;
        
        private EndOperationDelegate onEndSetMoveMetadataDelegate;
        
        private System.Threading.SendOrPostCallback onSetMoveMetadataCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public GameServiceClient() {
        }
        
        public GameServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GameServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetStartMetadataCompletedEventArgs> GetStartMetadataCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SetMoveMetadataCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult GamePlugin.Game.GameService.BeginGetStartMetadata(string gameId, string userId, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetStartMetadata(gameId, userId, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string GamePlugin.Game.GameService.EndGetStartMetadata(System.IAsyncResult result) {
            return base.Channel.EndGetStartMetadata(result);
        }
        
        private System.IAsyncResult OnBeginGetStartMetadata(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string gameId = ((string)(inValues[0]));
            string userId = ((string)(inValues[1]));
            return ((GamePlugin.Game.GameService)(this)).BeginGetStartMetadata(gameId, userId, callback, asyncState);
        }
        
        private object[] OnEndGetStartMetadata(System.IAsyncResult result) {
            string retVal = ((GamePlugin.Game.GameService)(this)).EndGetStartMetadata(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetStartMetadataCompleted(object state) {
            if ((this.GetStartMetadataCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetStartMetadataCompleted(this, new GetStartMetadataCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetStartMetadataAsync(string gameId, string userId) {
            this.GetStartMetadataAsync(gameId, userId, null);
        }
        
        public void GetStartMetadataAsync(string gameId, string userId, object userState) {
            if ((this.onBeginGetStartMetadataDelegate == null)) {
                this.onBeginGetStartMetadataDelegate = new BeginOperationDelegate(this.OnBeginGetStartMetadata);
            }
            if ((this.onEndGetStartMetadataDelegate == null)) {
                this.onEndGetStartMetadataDelegate = new EndOperationDelegate(this.OnEndGetStartMetadata);
            }
            if ((this.onGetStartMetadataCompletedDelegate == null)) {
                this.onGetStartMetadataCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetStartMetadataCompleted);
            }
            base.InvokeAsync(this.onBeginGetStartMetadataDelegate, new object[] {
                        gameId,
                        userId}, this.onEndGetStartMetadataDelegate, this.onGetStartMetadataCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult GamePlugin.Game.GameService.BeginSetMoveMetadata(string gameId, string userId, string metadata, int currentMoveNumber, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSetMoveMetadata(gameId, userId, metadata, currentMoveNumber, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void GamePlugin.Game.GameService.EndSetMoveMetadata(System.IAsyncResult result) {
            base.Channel.EndSetMoveMetadata(result);
        }
        
        private System.IAsyncResult OnBeginSetMoveMetadata(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string gameId = ((string)(inValues[0]));
            string userId = ((string)(inValues[1]));
            string metadata = ((string)(inValues[2]));
            int currentMoveNumber = ((int)(inValues[3]));
            return ((GamePlugin.Game.GameService)(this)).BeginSetMoveMetadata(gameId, userId, metadata, currentMoveNumber, callback, asyncState);
        }
        
        private object[] OnEndSetMoveMetadata(System.IAsyncResult result) {
            ((GamePlugin.Game.GameService)(this)).EndSetMoveMetadata(result);
            return null;
        }
        
        private void OnSetMoveMetadataCompleted(object state) {
            if ((this.SetMoveMetadataCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SetMoveMetadataCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SetMoveMetadataAsync(string gameId, string userId, string metadata, int currentMoveNumber) {
            this.SetMoveMetadataAsync(gameId, userId, metadata, currentMoveNumber, null);
        }
        
        public void SetMoveMetadataAsync(string gameId, string userId, string metadata, int currentMoveNumber, object userState) {
            if ((this.onBeginSetMoveMetadataDelegate == null)) {
                this.onBeginSetMoveMetadataDelegate = new BeginOperationDelegate(this.OnBeginSetMoveMetadata);
            }
            if ((this.onEndSetMoveMetadataDelegate == null)) {
                this.onEndSetMoveMetadataDelegate = new EndOperationDelegate(this.OnEndSetMoveMetadata);
            }
            if ((this.onSetMoveMetadataCompletedDelegate == null)) {
                this.onSetMoveMetadataCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSetMoveMetadataCompleted);
            }
            base.InvokeAsync(this.onBeginSetMoveMetadataDelegate, new object[] {
                        gameId,
                        userId,
                        metadata,
                        currentMoveNumber}, this.onEndSetMoveMetadataDelegate, this.onSetMoveMetadataCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override GamePlugin.Game.GameService CreateChannel() {
            return new GameServiceClientChannel(this);
        }
        
        private class GameServiceClientChannel : ChannelBase<GamePlugin.Game.GameService>, GamePlugin.Game.GameService {
            
            public GameServiceClientChannel(System.ServiceModel.ClientBase<GamePlugin.Game.GameService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetStartMetadata(string gameId, string userId, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = gameId;
                _args[1] = userId;
                System.IAsyncResult _result = base.BeginInvoke("GetStartMetadata", _args, callback, asyncState);
                return _result;
            }
            
            public string EndGetStartMetadata(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("GetStartMetadata", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginSetMoveMetadata(string gameId, string userId, string metadata, int currentMoveNumber, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[4];
                _args[0] = gameId;
                _args[1] = userId;
                _args[2] = metadata;
                _args[3] = currentMoveNumber;
                System.IAsyncResult _result = base.BeginInvoke("SetMoveMetadata", _args, callback, asyncState);
                return _result;
            }
            
            public void EndSetMoveMetadata(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("SetMoveMetadata", _args, result);
            }
        }
    }
}
