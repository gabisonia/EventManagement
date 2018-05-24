using Shared;

namespace EventManagement.SeatTypeAggregate
{
    public class SeatTypeSnapshotProvider : SnapshotProvider<SeatTypeSnapshot>
    {
        public SeatTypeSnapshotProvider(IProvideSnapshot<SeatTypeSnapshot> snapshotContainer)
            : base(snapshotContainer)
        {
        }
    }
}
