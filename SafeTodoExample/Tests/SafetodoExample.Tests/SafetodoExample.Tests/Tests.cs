using System;
using System.Threading.Tasks;
using SafeTodoExample.Helpers;
using SafeTodoExample.ViewModel;
using Xamarin.Forms;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace SafetodoExample.Tests
{
    public class Tests
    {
        [Fact]
        public void IsMockAppTest()
        {
            try
            {
                Assert.True(SafeApp.AppBindings.AppResolver.Current.IsMockBuild());
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        [Fact]
        public async Task MockAuthenticationTest()
        {
            try
            {
                bool messageReceived = false;
                var authViewModel = new MainPageViewModel();

                MessagingCenter.Subscribe<MainPageViewModel>(
                    this, MessengerConstants.NavigateToItemPage, sender =>
                    {
                        messageReceived = true;
                    });

                await authViewModel.ConnectToMockAsync();
                Assert.True(messageReceived);
                authViewModel.AppService.Dispose();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        [Fact]
        public async Task MutableOperationsTest()
        {
            try
            {
                bool messageReceived = false;
                var authViewModel = new MainPageViewModel();

                MessagingCenter.Subscribe<MainPageViewModel>(
                    this, MessengerConstants.NavigateToItemPage, sender =>
                    {
                        messageReceived = true;
                    });

                await authViewModel.ConnectToMockAsync();
                Assert.True(messageReceived);

                var todoItemsViewModel = new TodoItemsPageViewModel();

                // Test get mdata entries
                await todoItemsViewModel.OnRefreshItemsCommand();
                Assert.Empty(todoItemsViewModel.ToDoItems);

                var addItemViewModel = new AddItemViewModel();

                // Test add todo item
                messageReceived = false;
                MessagingCenter.Subscribe<AddItemViewModel>(
                    this, MessengerConstants.RefreshItemList, sender =>
                    {
                        messageReceived = true;
                    });
                addItemViewModel.Title = Misc.GetRandomString(10);
                addItemViewModel.Details = Misc.GetRandomString(10);
                await addItemViewModel.OnAddItemCommand();
                Assert.True(messageReceived, "Adding entry failed");

                // Test fetch todo items
                await todoItemsViewModel.OnRefreshItemsCommand();
                Assert.NotEmpty(todoItemsViewModel.ToDoItems);

                // Test add second todo item
                messageReceived = false;
                addItemViewModel.Title = Misc.GetRandomString(10);
                addItemViewModel.Details = Misc.GetRandomString(10);
                await addItemViewModel.OnAddItemCommand();
                Assert.True(messageReceived, "Adding entry failed");

                // Test fetch todo items
                await todoItemsViewModel.OnRefreshItemsCommand();
                Assert.NotEmpty(todoItemsViewModel.ToDoItems);
                Assert.Equal(2, todoItemsViewModel.ToDoItems.Count);

                // Test delete todo item
                await todoItemsViewModel.DeleteItemAsync(todoItemsViewModel.ToDoItems[0]);
                await todoItemsViewModel.OnRefreshItemsCommand();
                Assert.Single(todoItemsViewModel.ToDoItems);

                // Test update todo item
                var updateViewModel = new AddItemViewModel(todoItemsViewModel.ToDoItems[0], true);
                var newDetails = "UpdatedDetails";
                updateViewModel.Details = newDetails;
                await updateViewModel.OnAddItemCommand();
                await todoItemsViewModel.OnRefreshItemsCommand();
                Assert.Single(todoItemsViewModel.ToDoItems);
                Assert.Equal(newDetails, todoItemsViewModel.ToDoItems[0].Detail);

                authViewModel.AppService.Dispose();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }
    }
}
