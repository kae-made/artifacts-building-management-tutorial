// ------------------------------------------------------------------------------
// <auto-generated>
//     This file is generated by tool.
//     Runtime Version : 1.0.0
//  
//     Updates this file cause incorrect behavior 
//     and will be lost when the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Kae.StateMachine;
using Kae.Utility.Logging;
using Kae.DomainModel.Csharp.Framework;
using Kae.DomainModel.Csharp.Framework.Adaptor.ExternalStorage;

namespace BuildingManagement
{
    public partial class DomainClassMIBase : DomainClassMI
    {
        protected static readonly string className = "MI";

        public string DomainName { get { return CIMBuildingManagementLib.DomainName; }}
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;


        public string GetIdForExternalStorage() {  return $"MeasuringInstId={attr_MeasuringInstId}"; }

        public static DomainClassMIBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null, bool synchronousMode = false)
        {
            var newInstance = new DomainClassMIBase(instanceRepository, logger, synchronousMode);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:MI(MeasuringInstId={newInstance.Attr_MeasuringInstId}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassMIBase(InstanceRepository instanceRepository, Logger logger, bool synchronousMode)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_MeasuringInstId = Guid.NewGuid().ToString();
        }
        protected string attr_MeasuringInstId;
        protected bool stateof_MeasuringInstId = false;

        protected string attr_TargetRoomId;
        protected bool stateof_TargetRoomId = false;

        protected string attr_ModelName;
        protected bool stateof_ModelName = false;

        protected DomainTypeEnvironmentPhysicalQuantities attr_Environment = new DomainTypeEnvironmentPhysicalQuantities() ;
        protected bool stateof_Environment = false;

        protected int attr_RequestInterval;
        protected bool stateof_RequestInterval = false;

        protected int attr_CurrentInterval;
        protected bool stateof_CurrentInterval = false;

        protected string attr_DeviceStatus;
        protected bool stateof_DeviceStatus = false;

        public string Attr_MeasuringInstId { get { return attr_MeasuringInstId; } set { attr_MeasuringInstId = value; stateof_MeasuringInstId = true; } }
        public string Attr_TargetRoomId { get { return attr_TargetRoomId; } }
        public string Attr_ModelName { get { return attr_ModelName; } set { attr_ModelName = value; stateof_ModelName = true; } }
        public DomainTypeEnvironmentPhysicalQuantities Attr_Environment { get { return attr_Environment; } set { attr_Environment = value; stateof_Environment = true; } }
        public int Attr_RequestInterval { get { return attr_RequestInterval; } set { attr_RequestInterval = value; stateof_RequestInterval = true; } }
        public int Attr_CurrentInterval { get { return attr_CurrentInterval; } set { attr_CurrentInterval = value; stateof_CurrentInterval = true; } }
        public string Attr_DeviceStatus { get { return attr_DeviceStatus; } set { attr_DeviceStatus = value; stateof_DeviceStatus = true; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassMI instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "MeasuringInstId":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_MeasuringInstId)
                        {
                            result = false;
                        }
                        break;
                    case "TargetRoomId":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_TargetRoomId)
                        {
                            result = false;
                        }
                        break;
                    case "ModelName":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_ModelName)
                        {
                            result = false;
                        }
                        break;
                    case "Environment":
                        if ((DomainTypeEnvironmentPhysicalQuantities)conditionPropertyValues[propertyName] != instance.Attr_Environment)
                        {
                            result = false;
                        }
                        break;
                    case "RequestInterval":
                        if ((int)conditionPropertyValues[propertyName] != instance.Attr_RequestInterval)
                        {
                            result = false;
                        }
                        break;
                    case "CurrentInterval":
                        if ((int)conditionPropertyValues[propertyName] != instance.Attr_CurrentInterval)
                        {
                            result = false;
                        }
                        break;
                    case "DeviceStatus":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_DeviceStatus)
                        {
                            result = false;
                        }
                        break;
                }
                if (result== false)
                {
                    break;
                }
            }
            return result;
        }
        protected LinkedInstance relR3RMeasuaring;
        public DomainClassR LinkedR3Measuaring()
        {
            if (relR3RMeasuaring == null)
            {
                var candidates = instanceRepository.GetDomainInstances("R").Where(inst=>(this.Attr_TargetRoomId==((DomainClassR)inst).Attr_RoomId));
                if (candidates.Count() == 0)
                {
                   if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "R", "R3", candidates, () => { return DomainClassRBase.CreateInstance(instanceRepository, logger); }, "any").Result;
                }
                relR3RMeasuaring = new LinkedInstance() { Source = this, Destination = candidates.FirstOrDefault(), RelationshipID = "R3", Phrase = "Measuaring" };

            }
            return relR3RMeasuaring.GetDestination<DomainClassR>();
        }

        public bool LinkR3Measuaring(DomainClassR instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR3RMeasuaring == null)
            {
                this.attr_TargetRoomId = instance.Attr_RoomId;
                this.stateof_TargetRoomId = true;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:MI(MeasuringInstId={this.Attr_MeasuringInstId}):link[R(RoomId={instance.Attr_RoomId})]");

                result = (LinkedR3Measuaring()!=null);
                if (result)
                {
                    if(changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR3RMeasuaring });
                }
            }
            return result;
        }

        public bool UnlinkR3Measuaring(DomainClassR instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR3RMeasuaring != null && ( this.Attr_TargetRoomId==instance.Attr_RoomId ))
            {
                if (changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR3RMeasuaring });
        
                this.attr_TargetRoomId = null;
                this.stateof_TargetRoomId = true;
                relR3RMeasuaring = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:MI(MeasuringInstId={this.Attr_MeasuringInstId}):unlink[R(RoomId={instance.Attr_RoomId})]");


                result = true;
            }
            return result;
        }

        public IEnumerable<DomainClassAT> LinkedR6OtherAffect()
        {
            var result = new List<DomainClassAT>();
            var candidates = instanceRepository.GetDomainInstances("AT").Where(inst=>(this.Attr_MeasuringInstId==((DomainClassAT)inst).Attr_MeasuringInstId));
            if (instanceRepository.ExternalStorageAdaptor != null) candidates = instanceRepository.ExternalStorageAdaptor.CheckTraverseStatus(DomainName, this, "AT", "R6_Affect", candidates, () => { return DomainClassATBase.CreateInstance(instanceRepository, logger); }, "many").Result;
            foreach (var c in candidates)
            {
                ((DomainClassAT)c).LinkedR6One();
                result.Add((DomainClassAT)c);
            }
            return result;
        }



        
        public bool Validate()
        {
            bool isValid = true;
            if (relR3RMeasuaring == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:MI(MeasuringInstId={this.Attr_MeasuringInstId}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            if (propertyValues.ContainsKey("MeasuringInstId"))
            {
                attr_MeasuringInstId = (string)propertyValues["MeasuringInstId"];
            }
            stateof_MeasuringInstId = false;
            if (propertyValues.ContainsKey("TargetRoomId"))
            {
                attr_TargetRoomId = (string)propertyValues["TargetRoomId"];
            }
            stateof_TargetRoomId = false;
            if (propertyValues.ContainsKey("ModelName"))
            {
                attr_ModelName = (string)propertyValues["ModelName"];
            }
            stateof_ModelName = false;
            if (propertyValues.ContainsKey("Environment"))
            {
                attr_Environment.Restore((IDictionary<string, object>)propertyValues["Environment"]);
            }
            stateof_Environment = false;
            if (propertyValues.ContainsKey("RequestInterval"))
            {
                attr_RequestInterval = (int)propertyValues["RequestInterval"];
            }
            stateof_RequestInterval = false;
            if (propertyValues.ContainsKey("CurrentInterval"))
            {
                attr_CurrentInterval = (int)propertyValues["CurrentInterval"];
            }
            stateof_CurrentInterval = false;
            if (propertyValues.ContainsKey("DeviceStatus"))
            {
                attr_DeviceStatus = (string)propertyValues["DeviceStatus"];
            }
            stateof_DeviceStatus = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_MeasuringInstId)
            {
                results.Add("MeasuringInstId", attr_MeasuringInstId);
                stateof_MeasuringInstId = false;
            }
            if (stateof_TargetRoomId)
            {
                results.Add("TargetRoomId", attr_TargetRoomId);
                stateof_TargetRoomId = false;
            }
            if (stateof_ModelName)
            {
                results.Add("ModelName", attr_ModelName);
                stateof_ModelName = false;
            }
            if (stateof_Environment)
            {
                results.Add("Environment", attr_Environment);
                stateof_Environment = false;
            }
            if (stateof_RequestInterval)
            {
                results.Add("RequestInterval", attr_RequestInterval);
                stateof_RequestInterval = false;
            }
            if (stateof_CurrentInterval)
            {
                results.Add("CurrentInterval", attr_CurrentInterval);
                stateof_CurrentInterval = false;
            }
            if (stateof_DeviceStatus)
            {
                results.Add("DeviceStatus", attr_DeviceStatus);
                stateof_DeviceStatus = false;
            }

            return results;
        }

        public string GetIdentities()
        {
            string identities = $"MeasuringInstId={this.Attr_MeasuringInstId}";

            return identities;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            results.Add("MeasuringInstId", attr_MeasuringInstId);
            if (!onlyIdentity) results.Add("TargetRoomId", attr_TargetRoomId);
            if (!onlyIdentity) results.Add("ModelName", attr_ModelName);
            if (!onlyIdentity) results.Add("Environment", attr_Environment);
            if (!onlyIdentity) results.Add("RequestInterval", attr_RequestInterval);
            if (!onlyIdentity) results.Add("CurrentInterval", attr_CurrentInterval);
            if (!onlyIdentity) results.Add("DeviceStatus", attr_DeviceStatus);

            return results;
        }

#if false
        List<ChangedState> changedStates = new List<ChangedState>();

        public IList<ChangedState> ChangedStates()
        {
            List<ChangedState> results = new List<ChangedState>();
            results.AddRange(changedStates);
            results.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Update, Target = this, ChangedProperties = ChangedProperties() });
            changedStates.Clear();

            return results;
        }
#endif
    }
}
