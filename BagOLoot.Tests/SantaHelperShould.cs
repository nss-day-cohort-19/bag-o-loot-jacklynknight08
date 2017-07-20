using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot
{
    public class SantaHelperShould
    {
        SantaHelper _helper;
        public SantaHelperShould()
        {
            _helper = new SantaHelper();
        }

    //Items can be added to bag, and assigned to a child.
    [Fact]
    public void AddToyToChildsBag()
    {
        string toyName = "Skateboard";
        int childId = 715;
        int toyId = _helper.AddToyToBag(toyName, childId);
        List<int> toys = _helper.GetChildsToys(childId);

        Assert.Contains(toyId, toys);
    }
    //Items can be removed from bag, per child. Removing Ball, for example, from the bag should 
    //not be allowed. A child's name must be specified.
    [Fact]
    public void RemoveToyFromChildsBag()
    {
        int childId = 715;
        int toyId = 20; 
        _helper.RemoveChildsToy(toyId, childId);
        List<int> toys = _helper.GetChildsToys(childId);

        Assert.DoesNotContain(toyId, toys);
    }

    //Must be able to list all children who are getting a toy.
    [Fact]
    public void ListAllChildrenReceivingToy()
    {
        List<string>AllChildrenReceivingToy = _helper.GetAllChildrenReceivingToys();

        Assert.IsType<List<string>>(AllChildrenReceivingToy);
    }

    //Must be able to list all toys for a given child's name.
    [Fact]
    public void ListOfAllToysForEachChild()
    {
        int childId = 715;
        List <int> EveryToyListedForEachChild = _helper.GetEachChildsToys(childId);

        Assert.IsType <List<int>> (EveryToyListedForEachChild);
    }

    //Must be able to set the delivered property of a child, which defaults to false to true
     [Fact]
    public void SetDeliveryStatusForEachChild()
    {
        int childId = 715;
        bool deliveryStatus = _helper.ToyDeliveryStatus(childId);

        Assert.True (deliveryStatus);
    }   
}
}