using System.Collections;

public class PetArray {

    int Size;
    PetData[] List;
    int PetCount;

    public PetArray(int size) {
        this.Size = size;
        this.List = new PetData[size];
    }

    public bool IsEmpty() {
        return PetCount <= 0;
    }

    public bool IsFull() {
        return PetCount >= Size;
    }

    //Removes given pet and returns the position is was in. Returns -1 if not found
    public int RemovePet(PetData pet) {
        for(int i = 0; i < Size; i++) {
            if(ReferenceEquals(pet, List[i])) {
                List[i] = null;
                PetCount -= 1;
                return i;
            }
        }

        return -1;
    }

    //Tries to add the pet at the current index, returns true for successful
    public bool TryAddFriend(PetData friend, int index) {
        if(friend == null || index < 0 || index >= Size) throw new System.ArgumentOutOfRangeException();

        if(this.IsFull()) return false;

        if(List[index] == null) {
            List[index] = friend;
            PetCount += 1;
        } else {
            int direction = DetermineShiftDirection(index);

            PetData temp = List[index];
            PetData targetPet = friend;
            int nextIndex = index;
            while(temp != null) {
                List[nextIndex] = targetPet;
                targetPet = temp;

                nextIndex = nextIndex + direction;
                temp = List[nextIndex];
            }
        }

        return true;
    }

    //Returns the direction, forwards (1) or backwards (-1) that the nearest empty slot is in the team.
    public int DetermineShiftDirection(int targetIndex) {
        for(int shiftIndex = 1; shiftIndex < Size; shiftIndex++) {
            for(int direction = -1; direction < 2; direction += 2) {
                int emptyIndex = targetIndex + (shiftIndex * direction);
                if( emptyIndex >= 0 && emptyIndex < Size && List[emptyIndex] == null ) return direction;
            }
        }

        throw new System.Exception("Team must not be full to shift pets");
    }

    public void ShiftAllPetsForward() {
        for(int i = 1; i < Size; i++) {
            if(List[i - 1] == null) {
                List[i - 1] = List[i];
                List[i] = null;
            }
        }
    }
}