using System;
using System.Linq;

public class PetArray
{

    public int Size => List.Length;

    public readonly PetData[] List;
    public int PetCount
    {
        get { return List.Count( x => x is { } ); }
    }

    public PetArray( int size )
    {
        List = new PetData[ size ];
    }

    public bool IsEmpty()
    {
        return PetCount <= 0;
    }

    public bool IsFull()
    {
        return PetCount >= Size;
    }

    public PetData GetPet( int index )
    {
        return List[ index ];
    }

    public PetData GetPetAhead( int index )
    {
        if ( index - 1 >= 0 && index - 1 < Size )
        {
            return List[ index - 1 ];
        }

        return null;
    }

    public PetData GetPetBehind( int index )
    {
        if ( index + 1 >= 0 && index + 1 < Size )
        {
            return List[ index + 1 ];
        }

        return null;
    }

    public PetData GetFirstPet()
    {
        if ( IsEmpty() )
        {
            return null;
        }

        while ( PetCount > 0 && GetPet( 0 ) is null ) ShiftAllPetsForward();

        return GetPet( 0 );
    }

    //Removes given pet and returns the position is was in. Returns -1 if not found
    public int RemovePet( PetData pet )
    {
        for ( int i = 0; i < Size; i++ )
        {
            if ( ReferenceEquals( pet, List[ i ] ) )
            {
                List[ i ] = null;
                return i;
            }
        }

        return -1;
    }

    //Tries to add the pet at the current index, returns true for successful
    public bool TryAddFriend( PetData friend, int index )
    {
        if ( friend == null || index < 0 || index >= Size )
        {
            throw new ArgumentOutOfRangeException();
        }

        if ( IsFull() )
        {
            return false;
        }

        if ( List[ index ] == null )
        {
            List[ index ] = friend;
        } else
        {
            int direction = DetermineShiftDirection( index );

            PetData temp = List[ index ];
            PetData targetPet = friend;
            int nextIndex = index;
            while ( temp != null )
            {
                List[ nextIndex ] = targetPet;
                targetPet = temp;

                nextIndex += direction;
                temp = List[ nextIndex ];
            }
        }
        UpdatePetPositions();
        return true;
    }

    //Returns the direction, forwards (1) or backwards (-1) that the nearest empty slot is in the team.
    public int DetermineShiftDirection( int targetIndex )
    {
        for ( int shiftIndex = 1; shiftIndex < Size; shiftIndex++ )
        {
            for ( int direction = -1; direction < 2; direction += 2 )
            {
                int emptyIndex = targetIndex + shiftIndex * direction;
                if ( emptyIndex >= 0 && emptyIndex < Size && List[ emptyIndex ] == null )
                {
                    return direction;
                }
            }
        }

        throw new Exception( "Team must not be full to shift pets" );
    }

    public void ShiftAllPetsForward()
    {
        for ( int i = 1; i < Size; i++ )
        {
            if ( List[ i - 1 ] is null )
            {
                List[ i - 1 ] = List[ i ];
                List[ i ] = null;
            }
        }

        UpdatePetPositions();
    }

    public void UpdatePetPositions()
    {
        for ( int i = 0; i < Size; i++ )
        {
            if ( List[ i ] is null )
            {
                continue;
            }

            List[ i ].Position = i;
        }
    }
}
