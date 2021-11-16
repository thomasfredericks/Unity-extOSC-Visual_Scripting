using Unity.VisualScripting;
using UnityEngine;

//Registering a string name for your custom event to hook it to an event. You can save this class in a separated file and add multiple events to it as public static strings.
public static class EventNames
{
   public static string MyCustomEvent = "MyCustomEvent";
}

[UnitTitle("On my Custom Event")]//Custom Event node to receive the event. Adding On to the node title as an event naming convention.
[UnitCategory("Events\\MyEvents")]//Setting the path to find the node in the fuzzy finder in Events > My Events.
public class MyCustomEvent : EventUnit<int>
{
   [DoNotSerialize]// No need to serialize ports.
   public ValueOutput result { get; private set; }// The event output data to return when the event is triggered.
   protected override bool register => true;

   // Adding an EventHook with the name of the event to the list of visual scripting events.
   public override EventHook GetHook(GraphReference reference)
   {
       return new EventHook(EventNames.MyCustomEvent);
   }
   protected override void Definition()
   {
       base.Definition();
       // Setting the value on our port.
       result = ValueOutput<int>(nameof(result));
   }
   // Setting the value on our port.
   protected override void AssignArguments(Flow flow, int data)
   {
       flow.SetValue(result, data);
   }
}