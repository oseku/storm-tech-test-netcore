using System.Linq;
using Microsoft.AspNetCore.Identity;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoItems;
using Xunit;

namespace Todo.Tests
{
    public class WhenTodoItemIsUpdated
    {
        private readonly TodoItem resultItem;
        private readonly TodoItemEditFields srcFields;

        public WhenTodoItemIsUpdated()
        {
            var todoList = new TestTodoListBuilder(new IdentityUser("alice@example.com"), "shopping")
                    .WithItem("bread", Importance.High, 0)
                    .Build()
                ;

            resultItem = todoList.Items.First();
            srcFields = TodoItemEditFieldsFactory.Create(resultItem);

            srcFields.Title = "beer";
            srcFields.IsDone = true;
            srcFields.ResponsiblePartyId = "simpson.homer@example.com";
            srcFields.Importance = Importance.Low;
            srcFields.Rank = 100;

            TodoItemEditFieldsFactory.Update(srcFields, resultItem);
            
        }

        [Fact]
        public void EqualTitle()
        {
            Assert.Equal(srcFields.Title, resultItem.Title);
        }

        [Fact]
        public void EqualIsDone()
        {
            Assert.Equal(srcFields.IsDone, resultItem.IsDone);
        }

        [Fact]
        public void EqualResponsiblePartyId()
        {
            Assert.Equal(srcFields.ResponsiblePartyId, resultItem.ResponsiblePartyId);
        }

        [Fact]
        public void EqualImportance()
        {
            Assert.Equal(srcFields.Importance, resultItem.Importance);
        }

        [Fact]
        public void EqualRank()
        {
            Assert.Equal(srcFields.Rank, resultItem.Rank);
        }
    }
}