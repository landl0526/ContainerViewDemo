using Foundation;
using System;
using UIKit;

namespace ContainerViewDemo
{
    public partial class ViewController : UIViewController
    {

        ContainerViewController containerViewController;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            MyTableView.Source = new MyTableSource(containerViewController);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "Container")
            {
                containerViewController = segue.DestinationViewController as ContainerViewController;
            }
        }
    }


    public class MyTableSource : UITableViewSource
    {
ContainerViewController container;

public MyTableSource(ContainerViewController viewController)
{
    container = viewController;
}

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell("Cell");

            cell.TextLabel.Text = "item" + indexPath.Row;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 2;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            container.segueIdentifireRecievedFromParent(indexPath.Row);
        }
    }
}